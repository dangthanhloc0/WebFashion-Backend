using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Entity;

namespace BACKENDEMO.Dtos
{
    public class NewOrderDetail
    {

        public int quantity { get; set; }

        public long price { get; set; }

        public int productId { get; set; }
    }
}