using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookEntities.Entities.Models.CommentsFolder
{
    public class AddComments
    {
        [Key]
        public long CommentId { get; set; }
        public string addComments { get; set; }
    }
}
