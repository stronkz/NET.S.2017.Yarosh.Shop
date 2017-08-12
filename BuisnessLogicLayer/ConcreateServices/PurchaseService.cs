using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBuisnessLogicLayer;
using IBuisnessLogicLayer.Entities;
using IDataAccessLayer.Repos;
using IDataAccessLayer;
using BuisnessLogicLayer.Mappers;

namespace BuisnessLogicLayer.ConcreateServices
{
    class PurchaseService : IPurchaseServiece
    {
        private readonly PurchaseEntity purchase;
        private readonly IRep<DALPurchase> repository;
        

        public PurchaseService(string buyerName, IRep<DALPurchase> repository)
        {
            this.repository = repository;
            purchase = new PurchaseEntity() {BuyerName=buyerName};
        }

        public void AddProduct(ProductEntity product)
        {
            purchase.Products.Add(product);
            
        }

        public void DeleteProduct(ProductEntity product)
        {
            purchase.Products.Remove(product);
        }

        public IEnumerable<ProductEntity> GetAllProducts()
        {
            return purchase.Products;
        }

        public void Buy()
        {
            repository.Create(purchase.ToDallPurchase());
        }
    }
}
