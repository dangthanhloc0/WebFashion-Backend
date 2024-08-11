using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;

namespace BACKENDEMO.Entity
{
    public class StateOrderDetail
    {
        public int Id { get; set; }

        [Required]
        // [StringLength("")]
        public  string State { get; set; }  
    }
}