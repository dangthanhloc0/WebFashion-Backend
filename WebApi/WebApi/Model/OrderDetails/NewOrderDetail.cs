

namespace WebApi.Model.OrderDetails
{
    public class NewOrderDetail
    {
        public Guid productId { get; set; }

        public int quantity { get; set; }

        public float price { get; set; }


    }
}