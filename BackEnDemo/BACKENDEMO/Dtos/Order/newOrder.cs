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
    
 
        public string Address { get; set; } = string.Empty;


        public int methodOfPaymentId { get; set; }  
        public int stateOrderId  { get; set; }


    }
}