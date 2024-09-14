using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Entity;

namespace BACKENDEMO.Dtos
{
    public class newOrder
    {
    
        public DateTime Date { get; set; }
 
        public string Address { get; set; } = string.Empty;


        public int methodOfPaymentId { get; set; }  
        public int stateOrderId  { get; set; }
        public ICollection<OrdertailDto> OrdertailDto { get; set; }
        public int  stateTransportId { get; set; }
    }
}