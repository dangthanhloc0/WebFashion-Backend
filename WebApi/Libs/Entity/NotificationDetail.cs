using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class NotificationDetail
    {
        public Guid productId { get; set; }

        public Product product { get; set; }

        public Guid notificationId { get; set; }
        public Notification notification { get; set; }
    }
}