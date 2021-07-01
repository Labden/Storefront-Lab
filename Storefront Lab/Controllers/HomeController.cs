using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Storefront_Lab.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Storefront_Lab.Controllers
{
    public class HomeController : Controller
    {
        ProductDBContext db = new ProductDBContext();
        public IActionResult Index()
        {
            List<Product> productList = db.Products.ToList();
            return View(productList);
        }
        public IActionResult View(List<Product> products)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
