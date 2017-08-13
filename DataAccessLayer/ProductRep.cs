using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer.Repos;
using IDataAccessLayer;
using System.Linq.Expressions;
using System.Data.Entity;
using ORMEF;

namespace DataAccessLayer
{
    public class ProductRep : IRep<DALProduct>
    {
        private readonly DbContext context;
        public ProductRep(DbContext context)
        {
            this.context = context;
        }
        public void Create(DALProduct pr)
        {
            Product newProduct = new Product()
            {
                Name = pr.ProductsName,
                Description = pr.Desription,
                Price = pr.Price,
                Category = context.Set<Category>().FirstOrDefault(i=>i.Name==pr.Category),
                Amount = pr.Amount,
                Purchase = context.Set<Purchase>().FirstOrDefault(i=>i.NameOfBuyer==pr.Buyer)

            };

            context.Set<Product>().Add(newProduct);
        }

        public void Delete(DALProduct pr)
        {
            Product productToDelete = new Product()
            {
                
                Name = pr.ProductsName,
                Description = pr.Desription,
                Price = pr.Price,
                Category = context.Set<Category>().FirstOrDefault(i => i.Name == pr.Category),
                Amount = pr.Amount,
                Purchase = context.Set<Purchase>().FirstOrDefault(i=>i.NameOfBuyer==pr.Buyer)
            };

            context.Set<Product>().FirstOrDefault(prod =>prod.Id==productToDelete.Id);

        }

        public IEnumerable<DALProduct> GetAll()
        {
            return context.Set<Product>().Select(i => new DALProduct()
            {
               
                ProductsName = i.Name,
                Desription = i.Description,
                Price = i.Price,
                Amount = i.Amount,
                Category = i.Category.Name,
                Buyer = i.Purchase.NameOfBuyer
                
            });
        }

        public DALProduct GetById(int id)
        {
            var product = context.Set<Product>().FirstOrDefault(prod => prod.Id == id);
            if (ReferenceEquals(product, null)) throw new InvalidOperationException();
            return new DALProduct()
            {
                ProductsName = product.Name,
                Desription = product.Description,
                Price = product.Price,
                Amount = product.Amount,
                Category = product.Category.Name,
                Buyer = product.Purchase.NameOfBuyer

            };
        }

        public void Update(DALProduct product)
        {
            
        }
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
