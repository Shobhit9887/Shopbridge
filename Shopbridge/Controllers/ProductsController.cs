using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopbridge.Models;
using Shopbridge.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductData _productData;

        public ProductsController(IProductData productData)
        {
            _productData = productData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetProducts()
        {
            return Ok(_productData.GetProducts());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var product = _productData.GetProduct(id);
            if (product != null)
            {
                return Ok(_productData.GetProduct(id));
            } else
            {

            }
            return NotFound($"Product with Id: {id} was not found!");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddProduct(Product product)
        {
            _productData.AddProduct(product);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + product.ProductId, product);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _productData.GetProduct(id);

            if(product != null)
            {
                _productData.DeleteProduct(product);
                return Ok($"Product Number: {product.ProductNumber} was deleted successfully");
            } else
            {
                return NotFound($"Product with Id: {id} was not found!");
            }
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditProduct(Guid id, Product product)
        {
            var existingProduct = _productData.GetProduct(id);

            if(existingProduct != null)
            {
                product.ProductId = existingProduct.ProductId;
                _productData.EditProduct(product);
            } 

            return Ok(product.Name + " edited Successfully");
        }
    }
}
