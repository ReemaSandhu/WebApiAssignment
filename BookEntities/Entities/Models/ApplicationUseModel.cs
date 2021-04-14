using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEntities.Entities.Models
{
    public class ApplicationUseModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
    }
}
