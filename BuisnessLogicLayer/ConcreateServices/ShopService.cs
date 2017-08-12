using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBuisnessLogicLayer;
using IBuisnessLogicLayer.Entities;
using IDataAccessLayer;
using IDataAccessLayer.Repos;
using BuisnessLogicLayer.Mappers;
namespace BuisnessLogicLayer.ConcreateServices
{
    class ShopService : IShopServiece
    {
        private readonly IRep<DALProduct> productService;
        private readonly IRep<DALPurchase> purchaseService;
        public ShopService(IRep<DALProduct>pr,IRep<DALPurchase>purch)
        {
            productService = pr;
            purchaseService = purch;
        }

        public void AddProductToShop(ProductEntity product)
        {
            productService.Create(product.ToDalProduct());
            productService.Commit();
        }

        public void DeleteProductFromShop(ProductEntity product)
        {
            productService.Delete(product.ToDalProduct());
            productService.Commit();
        }

        public void DeletePurchase(PurchaseEntity purchase)
        {
            purchaseService.Delete(purchase.ToDallPurchase());
        }

        public IEnumerable<ProductEntity> GetAllProducts()
        {
            return productService.GetAll().Select(i => i.ToBalProduct());
        }

        public IEnumerable<PurchaseEntity> GetAllPurchases()
        {
            return purchaseService.GetAll().Select(i=>i.ToBalPurchase());
        }

        public ProductEntity GetProduct(int id)
        {
            return productService.GetById(id).ToBalProduct();
        }

        public PurchaseEntity GetPurchase(int id)
        {
            return purchaseService.GetById(id).ToBalPurchase();
        }

    }
}
