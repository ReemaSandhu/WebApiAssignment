using BookBusinessLayer.Interface;
using BookEntities.Entities.Models;
using BookEntities.Entities.Models.BookCrudOperations;
using BookEntities.Entities.Models.Images;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;
        private readonly IBooksBO _booksComponent;

        public BookStoreController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IOptions<ApplicationSettings> appSettings, IBooksBO booksComponent)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _booksComponent = booksComponent;
        }
        [HttpPost]
        [Route("Register")]
        //POST: /api/ApplicationUser/Register
        public async  Task<Object> PostApplicationUser(ApplicationUseModel model)
        {
            model.Role = "Visitor";
            var applicationuser = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                FullName = model.Fullname
            };
            try
            {
                var result =await _userManager.CreateAsync(applicationuser, model.Password);
                await _userManager.AddToRoleAsync(applicationuser, model.Role);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("AddCoOwner")]
        //POST: /api/ApplicationUser/AddCoOwner
        public async Task<Object> AddingCoOwner(ApplicationUseModel model)
        {
            model.Role = "CoOwner";
            var applicationuser = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                FullName = model.Fullname
            };
            try
            {
                var result = await _userManager.CreateAsync(applicationuser, model.Password);
                await _userManager.AddToRoleAsync(applicationuser, model.Role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("Login")]
        //POST : /api/BookStore/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //Get role assigned to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("UserID", user.Id.ToString()),
                            new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                        }),
                    Expires = DateTime.UtcNow.AddDays(3),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token});
            }
            else
            {
                return BadRequest(new { message = "Username or Password is incorrect" });
            }
        }
        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddNewBook(Books bk)
        {
            _booksComponent.AddBook(bk);
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("parneet@123", "kaur.26parneet@gmail.com"));
            message.To.Add(new MailboxAddress("Pari", "parneet.kaur@netsolutions.com"));
            message.Subject = "New Book Is Added";
            message.Body = new TextPart("plain")
            {
                Text = "Visit the book store "
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("kaur.26parneet@gmail.com", "parneet@123");
                client.Send(message);
                client.Disconnect(true);
            }
            return Ok("Book Has been added");
        }

        [HttpGet]
        //[Authorize]
        [Route("GetBook")]
        public IActionResult GetBook()
        {
            var Bookss = _booksComponent.GetBooks();
            return Ok(Bookss);
        }

        [HttpDelete]
        [Route("DeleteBook")]
        public IActionResult DeleteBook(long Id)
        {
            var result = _booksComponent.DeleteBook(Id);
            return Ok("Book deleted Successfully");
        }

        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult UpdateBooks(Books bk)
        {
            _booksComponent.UpdateBook(bk);
            return Ok("Book Has Been Updated");
        }

        [HttpGet]
        [Route("IndBook")]
        public IActionResult ShowBookDetails(long BookId)
        {
            //Student std = _studentComponent.GetStudent().FirstOrDefault(x => x.StudentId == id);
            Books BookObj = _booksComponent.GetBookById(BookId);
            return Ok(BookObj);
        }

        

        }
}
