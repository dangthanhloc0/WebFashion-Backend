using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class MethodOfPayment
    {
        public int Id { get; set; }

        [Required]
        public string MethodName { get; set; } = string.Empty;

        public ICollection<Order> order { get; set; }
    }
}