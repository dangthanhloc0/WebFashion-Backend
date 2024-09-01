using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Helps
{
    public class QueryProduct
    {
        // query theo name      
        public string? productName {get; set;} = null;

        // null kh�ng l�m g�
        // true gi?m d?n
        // false t?ng d?n
        public bool? IsDecsendingByPrice { get; set; }

        // l?y t?t c? s?n ph?m thu?c 1 category
        public int ? categoryId { get; set; } = 0;

        // s? trang : v� d? trang 1 ,trang  2
        public int pageNumber {get; set;} = 1;
        // s? l??ng ph?n t? c� trong trang
        public int pageSize {get; set;} = 10;   
    }
}