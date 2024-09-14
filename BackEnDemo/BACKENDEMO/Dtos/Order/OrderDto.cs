using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Entity;

namespace BACKENDEMO.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public long totalPrice { get; set; }
        public string Address { get; set; } = string.Empty;
        public string AppUserId { get; set; }

        public String UserName { get; set; }
        public String stateOrder { get; set; }
        public ICollection<OrderDetail> orderDetails { get; set; }
        public String stateTransport { get; set; }
    }
}