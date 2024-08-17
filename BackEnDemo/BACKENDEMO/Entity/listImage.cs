using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    [Table("listImages")]
    public class listImage
    {
        public int productId { get; set; }

        public int imageId { get; set; }

        public ImageProduct ImageProducts { get; set; }

        public Product products { get; set; }
    }
}