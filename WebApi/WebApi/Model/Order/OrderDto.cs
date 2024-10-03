

namespace WebApi.Model.User
{
    public class OrderDto
    {
        public Guid Id  { get; set; } 
        public DateTime Date { get; set; }
        public float totalPrice { get; set; }
        public string Address { get; set; } = string.Empty;
        public string stateOrder { get; set; } = string.Empty;
        public string stateTransport { get; set; } = string.Empty;

        public string methodOfPayment { get; set; } = string.Empty;

    }
}