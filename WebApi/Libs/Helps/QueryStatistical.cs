using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Helps
{
    public class QueryStatistical
    {
        public int start { get; set; } = 1;
        public int end { get; set; } = 12;
        public int year { get; set; } = DateTime.Now.Year;
        public bool IsDecsendingByPrice { get; set; } = false;
    }
}
