using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBuisnessLogicLayer;
using IBuisnessLogicLayer.Entities;

namespace BuisnessLogicLayer.ConcreateServices
{
    class ShopService : IShopServiece
    {
        public void DeletePurchase(PurchaseEntity purchase)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseEntity> GetAllPurchases()
        {
            throw new NotImplementedException();
        }

        public PurchaseEntity GetPurchase(int id)
        {
            throw new NotImplementedException();
        }
    }
}
