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
        public int Id  { get; set; } 
        public DateTime Date { get; set; }
        public long totalPrice { get; set; }
        public string Address { get; set; } = string.Empty;
        public string stateOrder { get; set; } = string.Empty;
        public string stateTransport { get; set; } = string.Empty;

    }
}