using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class StateTransport
    {
        public int Id { get; set; }

        [Required]
        public string state { get; set; } = string.Empty;


        public ICollection<Order> orders { get; set; }
    }
}