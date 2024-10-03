using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class Notification
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description {get; set;} = string.Empty;
        public ICollection<NotificationDetail> notificationDetails { get; set; }

    }
}