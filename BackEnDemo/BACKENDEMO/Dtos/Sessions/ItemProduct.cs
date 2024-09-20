using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BACKENDEMO.Dtos.Sessions
{
    public class ItemProduct
    {
        [JsonProperty("ProductId")]
        public int ProductId { get; set; }
        [JsonProperty("Quantity")]
        public int Quantity { get; set; }   

    }
}
