using IBuisnessLogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBuisnessLogicLayer
{
    public interface IShopServiece
    {
        IEnumerable<PurchaseEntity> GetAllPurchases();
        PurchaseEntity GetPurchase(int id);
        void DeletePurchase(PurchaseEntity purchase);
        void AddProductToShop(ProductEntity product);
        void DeleteProductFromShop(ProductEntity product);
        IEnumerable<ProductEntity> GetAllProducts();
        ProductEntity GetProduct(int id);
    }
}
