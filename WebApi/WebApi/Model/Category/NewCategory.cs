using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model.Category
{
    public class NewCategory
    {

        [Required]
        public string CategorName { get; set; } = string.Empty;
    }
}