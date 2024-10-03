using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    [Table("listImages")]
    public class listImage
    {
        public Guid productId { get; set; }

        public Guid imageId { get; set; }

        public Image ImageProducts { get; set; }

        public Product products { get; set; }
    }
}