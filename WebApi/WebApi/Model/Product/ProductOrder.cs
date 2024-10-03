
namespace WebApi.Model.Product
{
    public class ProductOrder
    {
        public Guid ProductId { get; set; }

        public string productName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public double Price { get; set; } = 0;

        public int Quantity { get; set; } = 0;
    }
}
