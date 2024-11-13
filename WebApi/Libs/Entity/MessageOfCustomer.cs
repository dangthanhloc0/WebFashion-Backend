using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class MessageOfCustomer
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(5000,MinimumLength =0)]
        public string Message { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public ICollection<MessageDetail> messageDetails { get; set; }

        public string UserId { get; set; }
        public AppUser appUser { get; set; }
    }
}