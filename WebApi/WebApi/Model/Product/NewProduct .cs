
using Libs.Entity;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using WebApi.Model.Image;
using WebApi.Model.SizeDetail;


namespace WebApi.Model.Product
{
    public class NewProduct 
    {
        [Required]
        [StringLength(100,MinimumLength =5)]
        public string productName { get; set; } = string.Empty;
        [Required]
        [Range(0,10000000)]
        public int quantitySellSucesss {get; set;} =  0;

        [Required]
        [StringLength(200 ,MinimumLength =0)]
        public string Description {get; set;} =  string.Empty;
        [Required]
        public string Image {get; set;} = string.Empty;

        public int quantityStock { get; set; } = 0;
        [Required]
        public float Price { get; set; } =0;

        [Required]
        public Guid CategoryId { get; set; }
        public List<string> ? imageUrls { get; set; }

        public List<SizeDetailCreate> sizeDetails { get; set; } 

        // public ICollection<OrderDetail> orderDetails { get; set; }

        // public  ICollection<MessageDetails> messageDetails { get; set; }

        // public ICollection<NotificationDetails> notificationDetails { get; set; }  
    }
}