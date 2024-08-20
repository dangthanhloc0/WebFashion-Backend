using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    public class NotificationDetails
    {
        public int productId { get; set; }

        public Product product { get; set; }

        public int notificationId { get; set; }
        public Notification notification { get; set; }
    }
}