using Shopbridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopbridge.ProductData
{
    public class MockProductData : IProductData 
    {
        private List<Product> products = new List<Product>()
        {
            new Product()
            {
                ProductId = Guid.NewGuid(),
                Name = "Product1"
            },
            new Product()
            {
                ProductId = Guid.NewGuid(),
                Name = "Product2"
            }
        };
         
        public Product AddProduct(Product product)
        {
            product.ProductId = Guid.NewGuid();
            products.Add(product);

            return product;
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }

        public Product EditProduct(Product product)
        {
            var existingProduct = GetProduct(product.ProductId);
            existingProduct.Name = product.Name;
            return product;
        }

        public Product GetProduct(Guid id)
        {
            return products.FirstOrDefault(x => x.ProductId == id);
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
