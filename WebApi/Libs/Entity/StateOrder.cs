using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;

namespace Libs.Entity
{
    public class StateOrder
    {
        public int Id { get; set; }

        [Required]
        public  string State { get; set; }  


        public ICollection<Order> orders { get; set;}
    }
}