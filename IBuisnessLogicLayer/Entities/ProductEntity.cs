using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBuisnessLogicLayer.Entities
{
    public class ProductEntity
    {
        public string ProductsName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Category { get; set; }
        public string  Buyer { get; set; }
    }
}
