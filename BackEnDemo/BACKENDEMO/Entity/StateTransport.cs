using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    public class StateTransport
    {
        public int Id { get; set; }

        [Required]
        public string state { get; set; } = string.Empty;
    }
}