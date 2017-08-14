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
        /// <summary>
        /// Create Product Repository
        /// </summary>
        /// <param name="context">context for saving data</param>
        public ProductRep(DbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Add dal entity to storage
        /// </summary>
        /// <param name="pr">entity to be added</param>
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
        /// <summary>
        /// delete entity from storage
        /// </summary>
        /// <param name="pr">entity to be removed</param>
        public void Delete(DALProduct pr)
        {
         
            Product productToDelete = context.Set<Product>()
                .FirstOrDefault(i => 
                i.Name == pr.ProductsName &&
                i.Description == pr.Desription&&
                i.Price==pr.Price&&
                i.Category.Name==pr.Category
                );
            if(ReferenceEquals(productToDelete,null)) throw new InvalidOperationException("not such product in db");
            context.Set<Product>().Remove(productToDelete);

        }
        /// <summary>
        /// Get all products from the storage
        /// </summary>
        /// <returns>collection of entities</returns>
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
        /// <summary>
        /// Get entity by it's Id
        /// </summary>
        /// <param name="id">id of expected entity</param>
        /// <exception cref="ArgumentOutOfRangeException">thrown when there is no such entity</exception>
        /// <returns>enity</returns>
        public DALProduct GetById(int id)
        {
            var product = context.Set<Product>().FirstOrDefault(prod => prod.Id == id);
            if (ReferenceEquals(product, null)) throw new ArgumentOutOfRangeException("no such id in data layer");
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
        /// <summary>
        /// updata entity
        /// </summary>
        /// <param name="product">entity to be chanched</param>
        public void Update(DALProduct product)
        {
            //coming soon
        }
        /// <summary>
        /// save changes to storage
        /// </summary>
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
