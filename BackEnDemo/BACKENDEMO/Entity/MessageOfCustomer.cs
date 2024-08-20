using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    public class MessageOfCustomer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(5000,MinimumLength =0)]
        public string Message { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public int MessageOfCustomerId { get; set; }

        public ICollection<MessageDetails> messageDetails { get; set; }

        public int appUserId { get; set; }

        public AppUser appUser { get; set; }
    }
}