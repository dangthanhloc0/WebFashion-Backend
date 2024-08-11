using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Helps
{
    public class QueryObject
    {
        public String? symbol {get; set;} = null;

        public String? company {get; set;} = null;
        public String? shortBy {get; set;} = null;

        public bool IsDecsending {get; set;} = false;

        public int pageNumber {get; set;} = 1;

        public int pageSize {get; set;} = 10;
    }
}