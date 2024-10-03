using Newtonsoft.Json;


namespace WebApi.Model.Sessions
{
    public class ItemProduct
    {
        [JsonProperty("ProductId")]
        public Guid ProductId { get; set; }
        [JsonProperty("Quantity")]
        public int Quantity { get; set; }
        [JsonProperty("price")]
        public float price { get; set; }

    }
}
