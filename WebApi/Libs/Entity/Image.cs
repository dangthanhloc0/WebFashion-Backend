using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    [Table("ImageProducts")]
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<listImage> ListImages { get; set; }

    }
}