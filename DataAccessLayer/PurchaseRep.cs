using IDataAccessLayer;
using IDataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ORMEF;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class PurchaseRep : IRep<DALPurchase>
    {
        private readonly DbContext context;
        /// <summary>
        /// create Purchase repository
        /// </summary>
        /// <param name="context">context for storage data</param>
        public PurchaseRep(DbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Create purchase
        /// </summary>
        /// <param name="purchase">purchase to be added to the storage</param>
        public void Create(DALPurchase purchase)
        {
            Purchase purch = new Purchase()
            {
                NameOfBuyer = purchase.BuyerName,
               
            };

            context.Set<Purchase>().Add(purch);
        }
        /// <summary>
        /// Delete purchase from the storage
        /// </summary>
        /// <param name="purchase">purchase to be deleted</param>
        /// <exception cref="InvalidOperationException">thrown when there is no such purchase in the storage</exception>
        public void Delete(DALPurchase purchase)
        {
            Purchase purchToDelete = context.Set<Purchase>()
                .FirstOrDefault(purch => purch.NameOfBuyer == purchase.BuyerName);
            if(ReferenceEquals(purchToDelete,null)) throw new InvalidOperationException("no such purchase");
            context.Set<Purchase>().Remove(purchToDelete);
        }
        /// <summary>
        /// get all purchases from storage
        /// </summary>
        /// <returns>collection of purchases</returns>
        public IEnumerable<DALPurchase> GetAll()
        {
            return context.Set<Purchase>().Select(i => new DALPurchase()
            {
                Id = i.Id,
                BuyerName=i.NameOfBuyer
            });
        }
        /// <summary>
        /// get purchase by it's Id
        /// </summary>
        /// <param name="id">id of expected purchase</param>
        /// <exception cref="InvalidOperationException">thrown when there is no such purchase in the storage</exception>
        /// <returns>purchase</returns>
        public DALPurchase GetById(int id)
        {
            var purch = context.Set<Purchase>().FirstOrDefault(i => i.Id == id);
            if (ReferenceEquals(purch, null)) throw new ArgumentOutOfRangeException();
            return new DALPurchase()
            {
                Id = purch.Id,
                BuyerName = purch.NameOfBuyer
            };
        }
        /// <summary>
        /// update purchase
        /// </summary>
        /// <param name="entity">purchase to be changed</param>
        public void Update(DALPurchase entity)
        {
            //comeing soon
        }
        /// <summary>
        /// saving changes to the storage
        /// </summary>
        public void Commit()
        {
                context.SaveChanges();
        }
    }
}
