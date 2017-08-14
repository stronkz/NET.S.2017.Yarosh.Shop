using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExceptions
{
    public class ProductNotFoundException:Exception
    {
        public ProductNotFoundException(string mess):base(mess)
        {
            
        }
    }

    public class PurchaseNotFoundException : Exception
    {
        public PurchaseNotFoundException(string mess):base(mess)
        {
            
        }
    }
}
