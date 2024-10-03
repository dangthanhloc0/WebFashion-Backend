

namespace WebApi.Model.Product
{
    public class product
    {
        public Guid Id { get; set; }

        public string productName { get; set; } = string.Empty;
        
        public int quantitySellSucesss {get; set;} =  0;


        public string Description {get; set;} =  string.Empty;

        public string Image {get; set;} = string.Empty;

        public long quantityStock { get; set; } = 0;

        public double Price { get; set; } =0;

        public String categoryName { get; set; } = null;

        public List<string> ListStringImage { get; set; }

    }
}