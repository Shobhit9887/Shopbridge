using Shopbridge.Models;
using Shopbridge.Controllers;
using System.Collections.Generic;
using Shopbridge.ProductData;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Net;

namespace Tests
{
    [TestFixture]
    public class ProductTests
    {
        private static DbContextOptions<ProductContext> dbContextOptions = new DbContextOptionsBuilder<ProductContext>()
            .UseInMemoryDatabase(databaseName: "ShopbridgeDb")
            .Options;

        ProductContext context;        

        [OneTimeSetUp]
        public void Setup()
        {
            context = new ProductContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();
        }

        [Test]
        public void CanFetchAllProducts()
        {            
            var dbProductData = new DbProductData(context);

            var result = dbProductData.GetProducts();

            Assert.IsInstanceOf<List<Product>>(result);
        }

        [Test]
        public void CanFetchSingleProduct_GivenProductId_ReturnsExistingProduct()
        {
            var dbProductData = new DbProductData(context);

            var result = dbProductData.GetProduct(new System.Guid("bf40c6cb-5722-4f17-b5f2-1f76f5dafb51"));

            Assert.IsTrue(result != null && result.ProductNumber == 2);
        }

        [Test]
        public void CanFetchSingleProduct_GivenProductId_ReturnsFalse()
        {
            var dbProductData = new DbProductData(context);

            var result = dbProductData.GetProduct(new System.Guid("c83f3ce2-658e-4e9b-bae7-17735ea42971"));

            Assert.IsTrue(result == null);
        }

        [Test]
        public void CanAddProduct_GivenProduct_ReturnsProductBack()
        {
            var dbProductData = new DbProductData(context);

            var product = new Product()
            {
                ProductId = new System.Guid("bf40c6cb-5722-4f17-c5f1-1d36f5dcfb53"),
                ProductNumber = 7,
                Name = "Product7",
                Description = "This is the seventh product",
                Price = 59.99,
                Quantity = 4
            };
            var result = dbProductData.AddProduct(product);

            Assert.IsTrue(result == product);
        }

        [Test]
        public void CanDeleteProduct_GivenProduct_ReturnsProductIdBack()
        {
            var dbProductData = new DbProductData(context);

            var id = new System.Guid("bf40c6cb-5722-4f17-c5f1-1d36f5dcfb51");
            Product product = context.Products.Find(id);
            var result = dbProductData.DeleteProduct(product);

            Assert.IsTrue(result == id);
        }


        [Test]
        public void CanEditProduct_GivenProductId_ReturnsProductBack()
        {
            var dbProductData = new DbProductData(context);

            var id = new System.Guid("c83f3ce2-658e-4e9b-bae7-17735ea42972");
            Product product = context.Products.Find(id);
            product.Name = "Edited Product1";
            product.ProductNumber = 5;
            product.Description = "This is the edited first product";
            product.Price = 69.99;
            product.Quantity = 100;
            var result = dbProductData.EditProduct(product);

            Assert.IsTrue(result == product);
        }

        [Test]
        public void CanEditProduct_GivenProductId_ReturnsErrorBack()
        {
            var dbProductData = new DbProductData(context);

            var id = new System.Guid("bf40c6cb-5722-4f17-c5f1-1d36f5dcfb52");
            Product existingProduct = context.Products.Find(id);
            Product product = existingProduct;
            product.Name = "Edited Product4";
            product.ProductNumber = 6;
            product.Description = "This is the edited fourth product";
            product.Price = 69.99;
            product.Quantity = 100;
            context.Products.Remove(existingProduct);
            context.SaveChanges();
            var result = dbProductData.EditProduct(product);

            Assert.IsTrue(result != product);
        }

        [OneTimeTearDown]
        public void Clear()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
            var productData = new List<Product>()
            {
                new Product()
                {
                    ProductId = new System.Guid("c83f3ce2-658e-4e9b-bae7-17735ea42972"),
                    ProductNumber = 1,
                    Name = "Product1",
                    Description = "This is the first product",
                    Price = 19.99,
                    Quantity = 5
                },
                new Product()
                {
                    ProductId = new System.Guid("bf40c6cb-5722-4f17-b5f2-1f76f5dafb51"),
                    ProductNumber = 2,
                    Name = "Product2",
                    Description = "This is the second product",
                    Price = 49.99,
                    Quantity = 2
                },
                new Product()
                {
                    ProductId = new System.Guid("bf40c6cb-5722-4f17-c5f1-1d36f5dcfb51"),
                    ProductNumber = 3,
                    Name = "Product3",
                    Description = "This is the third product",
                    Price = 99.99,
                    Quantity = 3
                },
                new Product()
                {
                    ProductId = new System.Guid("bf40c6cb-5722-4f17-c5f1-1d36f5dcfb52"),
                    ProductNumber = 4,
                    Name = "Product4",
                    Description = "This is the fourth product",
                    Price = 49.99,
                    Quantity = 4
                }
            };
            context.Products.AddRange(productData);
            context.SaveChanges();            
        }
    }
}
