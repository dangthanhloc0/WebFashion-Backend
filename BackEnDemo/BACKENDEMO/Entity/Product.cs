using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{

    [Table("products")]
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(100,MinimumLength =5)]
        public string productName { get; set; } = string.Empty;
        [Required]
        [Range(0,10000000)]
        public int quantityMaterial { get; set; }
        
        public int quantitySellSucesss {get; set;} =  0;

        [Required]
        [StringLength(200 ,MinimumLength =0)]
        public string Description {get; set;} =  string.Empty;

        [Required]
        public string Image {get; set;} = string.Empty;


        public long quantityStock { get; set; } = 0;

        [Required]
        public double Price { get; set; } =0;

        public int CategoryId { get; set; }

        public Category category { get; set; }

        public ICollection<listImage> ListImages { get; set; }

        public ICollection<OrderDetail> orderDetails { get; set; }

        public  ICollection<MessageDetails> messageDetails { get; set; }

        public ICollection<NotificationDetails> notificationDetails { get; set; }



        
    }
}