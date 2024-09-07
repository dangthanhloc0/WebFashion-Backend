using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string  CategorName { get; set; } = string.Empty;

        public ICollection<Product> ? products { get; set; }
    }
}