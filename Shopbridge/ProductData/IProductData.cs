using Shopbridge.Models;
using System;
using System.Collections.Generic;

namespace Shopbridge.ProductData
{
    public interface IProductData
    {
        List<Product> GetProducts();

        Product GetProduct(Guid id);

        Product AddProduct(Product product);

        Guid DeleteProduct(Product product);

        Product EditProduct(Product product);

    }
}
