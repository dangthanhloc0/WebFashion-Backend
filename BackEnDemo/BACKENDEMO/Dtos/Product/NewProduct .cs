using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BACKENDEMO.Dtos.Product
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

        public long quantityStock { get; set; } = 0;
        [Required]
        public double Price { get; set; } =0;

        public int CategoryId { get; set; }
        public ImageDto ListStringImage { get; set; }

        // public ICollection<OrderDetail> orderDetails { get; set; }

        // public  ICollection<MessageDetails> messageDetails { get; set; }

        // public ICollection<NotificationDetails> notificationDetails { get; set; }  
    }
}