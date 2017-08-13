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
        public PurchaseRep(DbContext context)
        {
            this.context = context;
        }
        public void Create(DALPurchase purchase)
        {
            Purchase purch = new Purchase()
            {
                NameOfBuyer = purchase.BuyerName,
                Products = purchase.Products.Select(i=>new Product()
                {
                    Name = i.ProductsName,
                    Category = i.Category,
                    Description = i.Desription,
                    Price = i.Price,
                    Amount = i.Amount,
                   
                }).ToList()
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

        public void Update(DALPurchase entity)
        {
            
        }
        public void Commit()
        {
            try
            {
                context.SaveChanges();
            }

            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Debug.Write(string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage));
                    }
                }
            }
        }
    }
}
