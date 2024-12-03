using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class MessageOfCustomer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(5000,MinimumLength =0)]
        public string Message { get; set; } = string.Empty;

        public string ? Image { get; set; } = string.Empty;


        public string AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        public DateTime Time { get; set; }

        public Guid productId { get; set; }

        public Product product { get; set; }
    }
}