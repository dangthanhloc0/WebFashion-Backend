using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public long totalPrice { get; set; }
        
        [Required]
        public string Address { get; set; } = string.Empty ;

        public string AppUserId { get; set; }

        public AppUser appUser { get; set; }

        public int methodOfPaymentId { get; set; }
        public MethodOfPayment methodOfPayment { get; set; }

        public int stateOrderId { get; set; }
        public StateOrder stateOrder { get; set; }

        public ICollection<OrderDetail> orderDetails { get; set; }

        public int stateTransportId { get; set; }

        public StateTransport stateTransport { get; set; }
    }
}