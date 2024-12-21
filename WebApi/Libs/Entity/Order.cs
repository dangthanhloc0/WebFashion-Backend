using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Entity
{
    [Table("Orders")]
    public class Order
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public float totalPrice { get; set; }
        
        [Required]
        public string Address { get; set; } = string.Empty ;

        [Required]
        public string Phone { get; set; } = string.Empty;

        public string UserId { get; set; }

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