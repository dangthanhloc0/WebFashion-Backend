using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    public class Category
    {
        public int Id { get; set; }
        
        public string  CategorName { get; set; } = string.Empty;

        public ICollection<Product> ? products { get; set; }
    }
}