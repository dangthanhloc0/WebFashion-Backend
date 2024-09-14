using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    [Table("ImageProducts")]
    public class ImageProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageProductId { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<listImage> ListImages { get; set; }

    }
}