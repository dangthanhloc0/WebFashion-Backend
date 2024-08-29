using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Entity;

namespace BACKENDEMO.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string productName { get; set; } = string.Empty;
        
        public int quantitySellSucesss {get; set;} =  0;


        public string Description {get; set;} =  string.Empty;

        public string Image {get; set;} = string.Empty;

        public long quantityStock { get; set; } = 0;

        public double Price { get; set; } =0;

        public Category category { get; set; }

        // public ICollection<listImage> ListImages { get; set; }

        // public ICollection<OrderDetail> orderDetails { get; set; }

        // public  ICollection<MessageDetails> messageDetails { get; set; }

        // public ICollection<NotificationDetails> notificationDetails { get; set; }
    }
}