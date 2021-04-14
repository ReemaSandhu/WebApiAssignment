using BookBusinessLayer.Interface;
using BookEntities.Entities.Models;
using BookEntities.Entities.Models.BookCrudOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IBooksBO _booksComponent;
        public UserProfileController(UserManager<ApplicationUser> userManager, IBooksBO booksComponent) 
        {
            _userManager = userManager;
            _booksComponent = booksComponent;
        }

        [HttpGet]
        [Authorize]
        //GET: api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName

            };
        }

        public IActionResult GetMessage()
        {
            return Ok("Hello");
        }
        [HttpGet]
        [Authorize(Roles ="Owner")]
        [Route("ForOwner")]
        public string GetForOwner()
        {
            return "owner can add edit delete books as well as add other co owners";
        }

        [HttpGet]
        [Authorize(Roles = "Visitor")]
        [Route("ForVisitor")]
        public string GetForVisitor()
        {
            return "Visitor can see the books and add comments";
        }

        [HttpGet]
        [Authorize(Roles = "Coowner")]
        [Route("ForCoowner")]
        public string GetForCoowner()
        {
            return "Coowner has same roles as owners";
        }
        //[HttpGet]
        ////[Authorize]
        //public IActionResult GetBook()
        //{
        //    return Ok(_booksComponent.GetBooks());
        //}

        //[HttpPost]
        //public IActionResult AddNewBook(Books bk)
        //{
        //    _booksComponent.AddBook(bk);
        //    return Ok("Book Has been added");
        //}
        //[HttpPost,DisableRequestSizeLimit]
        //public IActionResult Upload()
        //{
        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        if(file.Length>0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);
        //            using (var stream =new FileStream(fullPath,FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //            return Ok(new { dbPath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return StatusCode(500, $"Internal Server Error: {ex}");
        //    }
        //}
    }
}
