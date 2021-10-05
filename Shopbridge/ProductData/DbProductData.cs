using Shopbridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge.ProductData
{
    public class DbProductData : IProductData
    {
        private ProductContext _productContext;
        public DbProductData(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public Product AddProduct(Product product)
        {
            product.ProductId = Guid.NewGuid();
            _productContext.Products.Add(product);
            _productContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(Product product)
        {
            _productContext.Products.Remove(product);
            _productContext.SaveChanges();
            
        }

        public Product EditProduct(Product product)
        {
            var existingProduct = _productContext.Products.Find(product.ProductId);
            if(existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.ProductNumber = product.ProductNumber;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;

                _productContext.Products.Update(existingProduct);
                _productContext.SaveChanges();
            }
            return product;
        }

        public Product GetProduct(Guid id)
        {
            return _productContext.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public List<Product> GetProducts()
        {
            return _productContext.Products.ToList();
        }
    }
}
