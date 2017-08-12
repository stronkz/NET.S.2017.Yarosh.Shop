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

namespace DataAccessLayer
{
    class PurchaseRep : IRep<DALPurchase>
    {
        private readonly DbContext context;
        public PurchaseRep(DbContext context)
        {
            this.context = context;
        }
        public void Create(DALPurchase purchase)
        {
            Purchase purch = new Purchase()
            {
                NameOfBuyer = purchase.BuyerName
            };

            context.Set<Purchase>().Add(purch);
        }

        public void Delete(DALPurchase purchase)
        {
            Purchase purchToDelete = new Purchase { NameOfBuyer = purchase.BuyerName,Id=purchase.Id };

            context.Set<Purchase>().Remove(purchToDelete);
        }

        public IEnumerable<DALPurchase> GetAll()
        {
            return context.Set<Purchase>().Select(i => new DALPurchase()
            {
                Id = i.Id,
                BuyerName=i.NameOfBuyer
            });
        }

        public DALPurchase GetById(int id)
        {
            var purch = context.Set<Purchase>().FirstOrDefault(i => i.Id == id);
            if (ReferenceEquals(purch, null)) throw new InvalidOperationException();
            return new DALPurchase()
            {
                Id = purch.Id,
                BuyerName = purch.NameOfBuyer
            };
        }

        public DALPurchase GetByPredicate(Expression<Func<DALPurchase, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DALPurchase entity)
        {
            
        }
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
