using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShopbridgeMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopbridgeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList;
            HttpResponseMessage response = GlobalVariables.shopBridgeClient.GetAsync("products").Result;
            productList = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            return View(productList);
        }
        
        public IActionResult AddOrEdit(Guid? id = null)
        {
            if(id == null)
                return View(new Product());
            else
            {
                HttpResponseMessage response = GlobalVariables.shopBridgeClient.GetAsync("products/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Product>().Result);
            }
        }

        [HttpPost]
        public IActionResult AddOrEdit(Product product)
        {
            if (product.ProductId == Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.shopBridgeClient.PostAsJsonAsync("products", product).Result;
                    TempData["SuccessMessage"] = response.Content.ReadAsAsync<Product>().Result.Name + " was added successfully";
                } else
                {
                    return View(product);
                }
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.shopBridgeClient.PatchAsync("products/" + product.ProductId, new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json-patch+json")).Result;
                TempData["SuccessMessage"] = response.Content.ReadAsStringAsync().Result;
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            HttpResponseMessage response = GlobalVariables.shopBridgeClient.DeleteAsync("products/" + id).Result;
            TempData["SuccessMessage"] = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
