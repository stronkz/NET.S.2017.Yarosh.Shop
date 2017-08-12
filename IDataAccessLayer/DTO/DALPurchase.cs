using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccessLayer
{
    public class DALPurchase
    {
        public int Id { get; set; }
        public string  BuyerName { get; set; }
        public ICollection<DALProduct> Products { get; set; }
    }
}
