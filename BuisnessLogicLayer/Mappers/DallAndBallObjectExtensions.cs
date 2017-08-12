using IBuisnessLogicLayer.Entities;
using IDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Mappers
{
    public static class DallAndBallObjectExtensions
    {
        public static DALProduct ToDalProduct(this ProductEntity entity)
        {
            return new DALProduct()
            {
                ProductsName = entity.ProductsName,
                Desription = entity.Description,
                Amount = entity.Amount,
                Price = entity.Price,
                Category = entity.Category

            };
        } 
        public static ProductEntity ToBalProduct(this DALProduct entity)
        {
            return new ProductEntity()
            {
                ProductsName = entity.ProductsName,
                Description = entity.Desription,
                Amount = entity.Amount,
                Price = entity.Price,
                Category = entity.Category
            };
        }
        public static DALPurchase ToDallPurchase(this PurchaseEntity purchase)
        {
            return new DALPurchase()
            {
                BuyerName = purchase.BuyerName,
                Products = (ICollection<DALProduct>)purchase.Products.Select(pr=>pr.ToDalProduct())
            };
        }
        public static PurchaseEntity ToBalPurchase(this DALPurchase purchase)
        {
            return new PurchaseEntity()
            {
                BuyerName = purchase.BuyerName,
                Products = (ICollection<ProductEntity>)purchase.Products.Select(pr => pr.ToBalProduct())
            };
        }
    }
}
