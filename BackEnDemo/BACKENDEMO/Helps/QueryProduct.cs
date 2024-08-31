using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Helps
{
    public class QueryProduct
    {
        public string? productName {get; set;} = null;

        public bool? IsDecsendingByPrice { get; set; }

        public int categoryId { get; set; } = 0;

        public int pageNumber {get; set;} = 1;

        public int pageSize {get; set;} = 10;   
    }
}