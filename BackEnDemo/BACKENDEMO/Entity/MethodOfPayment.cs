using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    public class MethodOfPayment
    {
        public int Id { get; set; }

        [Required]
        public string MethodName { get; set; } = string.Empty;
    }
}