using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Helps
{
    public class QueryProduct
    {
        public String? productName {get; set;} = null;

        public String? price {get; set;} = null;
        public String? shortBy {get; set;} = null;

        public bool bigger { get; set; } = false;

        // public bool IsDecsending {get; set;} = false;

        public int pageNumber {get; set;} = 1;

        public int pageSize {get; set;} = 10;   
    }
}