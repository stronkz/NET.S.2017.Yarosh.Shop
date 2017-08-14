using IBuisnessLogicLayer.Entities;
using IDataAccessLayer;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IDataAccessLayer.Repos;

namespace BuisnessLogicLayer.Mappers
{
    internal static class DallAndBallObjectExtensions
    {
        /// <summary>
        /// Converte bal entity to entity on dal
        /// </summary>
        /// <param name="entity">entity to be converted</param>
        /// <returns>dal entity</returns>
        public static DALProduct ToDalProduct(this ProductEntity entity)
        {
            return new DALProduct()
            {
                ProductsName = entity.ProductsName,
                Desription = entity.Description,
                Amount = entity.Amount,
                Price = entity.Price,
                Category = entity.Category,
                Buyer = entity.Buyer
                
            };
        }
        /// <summary>
        /// Converte dal entity to entity on bal
        /// </summary>
        /// <param name="entity">entity to be converted</param>
        /// <returns>bal entity</returns>
        public static ProductEntity ToBalProduct(this DALProduct entity)
        {
            return new ProductEntity()
            {
                ProductsName = entity.ProductsName,
                Description = entity.Desription,
                Amount = entity.Amount,
                Price = entity.Price,
                Category = entity.Category,
                Buyer = entity.Buyer
                
            };
        }
        /// <summary>
        /// Converte bal entity to entity on dal
        /// </summary>
        /// <param name="entity">entity to be converted</param>
        /// <returns>dal entity</returns>
        public static DALPurchase ToDallPurchase(this PurchaseEntity purchase)
        {
            return new DALPurchase()
            {
                BuyerName = purchase.BuyerName,
                
            };
        }
        /// <summary>
        /// Converte dal entity to entity on bal
        /// </summary>
        /// <param name="entity">entity to be converted</param>
        /// <returns>bal entity</returns>
        public static PurchaseEntity ToBalPurchase(this DALPurchase purchase,IRep<DALProduct> context)
        {
            var pr = context;
            return new PurchaseEntity()
            {
                BuyerName = purchase.BuyerName,
                Products = pr.GetAll().Where(i=>i.Buyer==purchase.BuyerName).Select(i=>i.ToBalProduct()).ToList()
            };
        }
    }
}
