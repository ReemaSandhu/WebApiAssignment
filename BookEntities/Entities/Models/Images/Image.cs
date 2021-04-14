using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookEntities.Entities.Models.Images
{
    public class Image
    {
        [Key]
        public long ImageId { get; set; }
        public string ImageCaption { get; set; }
        public string Imagename { get; set; }

    }
}
