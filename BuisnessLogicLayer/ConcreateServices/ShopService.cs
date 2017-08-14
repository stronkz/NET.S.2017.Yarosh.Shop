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
using ShopExceptions;

namespace BuisnessLogicLayer.ConcreateServices
{
    public  class ShopService : IShopServiece
    {
        private readonly IRep<DALProduct> productService;
        private readonly IRep<DALPurchase> purchaseService;
        /// <summary>
        /// creating serviece
        /// </summary>
        /// <param name="pr">product repository</param>
        /// <param name="purch">purchase repository</param>
        /// <exception cref="ArgumentNullException">Thrown when one of reposityies is null</exception>
        public ShopService(IRep<DALProduct>pr,IRep<DALPurchase>purch)
        {
            if(pr==null) throw new ArgumentNullException("Product repository wasn't found");
            if (purch == null) throw new ArgumentNullException("Purchase repository wasn't found");

            productService = pr;
            purchaseService = purch;
        }
        /// <summary>
        /// Add product to the shop
        /// </summary>
        /// <param name="product">product to be added </param>
        /// <exception cref="ArgumentNullException">Product must not be null</exception>
        public void AddProductToShop(ProductEntity product)
        {
            if(ReferenceEquals(product,null)) throw new ArgumentNullException($"{nameof(product)} must not be null");

            productService.Create(product.ToDalProduct());
            productService.Commit();
        }
        /// <summary>
        /// Delete product from the shop
        /// </summary>
        /// <param name="product">product to be deleted</param>
        public void DeleteProductFromShop(ProductEntity product)
        {
            if(ReferenceEquals(product,null)) throw new ArgumentNullException($"{nameof(product)} must not be null");
            try
            {
                productService.Delete(product.ToDalProduct());
                productService.Commit();
            }
            catch (InvalidOperationException)
            {
                throw new ProductNotFoundException("No such product found in the shop");
            }
        }
        /// <summary>
        /// Delete purchase
        /// </summary>
        /// <param name="purchase">purchase to be deleted</param>
        public void DeletePurchase(PurchaseEntity purchase)
        {
            if(ReferenceEquals(purchase,null)) throw new ArgumentNullException($"{nameof(purchase)} must not be null");
            try
            {
                purchaseService.Delete(purchase.ToDallPurchase());
            }
            catch (InvalidOperationException )
            {
                throw new PurchaseNotFoundException("No such purchase in the shop");
            }
        }
        /// <summary>
        /// Get all product from the shop
        /// </summary>
        /// <returns>collection of products</returns>
        public IEnumerable<ProductEntity> GetAllProducts()
        {
            return productService.GetAll().Select(i => i.ToBalProduct());
        }
        /// <summary>
        /// Get all purchases from the shop
        /// </summary>
        /// <returns>collection of purchases</returns>
        public IEnumerable<PurchaseEntity> GetAllPurchases()
        {
            return purchaseService.GetAll().Select(i=>i.ToBalPurchase(productService));
        }
        /// <summary>
        /// find product by id
        /// </summary>
        /// <param name="id">id of expected product</param>
        /// <returns>product</returns>
        public ProductEntity GetProduct(int id)
        {
            try
            {
                return productService.GetById(id).ToBalProduct();
            }
            catch (ArgumentOutOfRangeException )
            {
                throw new ProductNotFoundException("No product was found");
            }
        }

        public PurchaseEntity GetPurchase(int id)
        {
            try
            {
                return purchaseService.GetById(id).ToBalPurchase(productService);
            }
            catch (ArgumentOutOfRangeException )
            {
                throw new PurchaseNotFoundException("No purchase was found");
            }
        }
        /// <summary>
        /// add purchase to the shop
        /// </summary>
        /// <param name="purch">purchase to be added</param>
        public void RegisterPurchase(PurchaseEntity purch)
        {
            if(ReferenceEquals(purch,null)) throw new ArgumentNullException($"{nameof(purch)} must not be null");

            purchaseService.Create(purch.ToDallPurchase());
            purchaseService.Commit();
        }
    }
}
