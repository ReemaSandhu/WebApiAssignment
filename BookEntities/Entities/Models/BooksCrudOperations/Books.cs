using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookEntities.Entities.Models.BookCrudOperations
{
    public class Books
    {
        [Key]
        public long BookId { get; set; }
        
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public long  PublicationYear { get; set; }
        public string BookDescription { get; set; }
        public long Price { get; set; }
        public string Comments { get; set; }
    }
}
