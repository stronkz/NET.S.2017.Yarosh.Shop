using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccessLayer
{
    public class DALProduct
    {
        public string ProductsName { get; set; }
        public string Desription { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Category { get; set; }
        public string  Buyer { get; set; }
    }
}
