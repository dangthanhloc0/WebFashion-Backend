using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;

using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Libs.Entity
{

    [Table("products")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        // Tên s?n ph?m
        [Required]
        [StringLength(100,MinimumLength =5)]
        public string productName { get; set; } = string.Empty;
        [Required]
        [Range(0,10000000)]
        // s? l??ng t?n kho
        public int quantityMaterial { get; set; }
        // s? l??ng bán thành công
        [JsonIgnore]
        public int quantitySellSucesss {get; set;} =  0;

        [Required]
        [StringLength(5000 ,MinimumLength =0)]
        public string Description {get; set;} =  string.Empty;

        [Required]
        public string Image {get; set;} = string.Empty;

        [JsonIgnore]
        public long quantityStock { get; set; } = 0;

        [Required]
        public float Price { get; set; } =0;

        public Guid CategoryId { get; set; }

        public Category ? category { get; set; }
        [JsonIgnore]
        public ICollection<listImage> ? ListImages { get; set; }
        [JsonIgnore]
        public ICollection<OrderDetail> ?  orderDetails { get; set; }
        [JsonIgnore]
        public  ICollection<MessageDetail> ? messageDetails { get; set; }
        [JsonIgnore]
        public ICollection<NotificationDetail> ? notificationDetails { get; set; }

        public ICollection<SizeDetail> ? sizeDetails { get; set; }  



        
    }
}