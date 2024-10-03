

using System.ComponentModel.DataAnnotations;

namespace WebApi.Model.User
{
    public class newOrder
   {

      [Required]
      public string Address { get; set; } = string.Empty;
      public int  methodOfPaymentId { get; set; }   
      public int  stateOrderId { get; set; }
      public int stateTransportId { get; set; }
    }
}