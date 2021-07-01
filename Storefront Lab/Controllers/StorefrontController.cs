using Microsoft.AspNetCore.Mvc;
using Storefront_Lab.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Storefront_Lab.Controllers
{
    public class StorefrontController : Controller
    {
        ProductDBContext db = new ProductDBContext();
        public IActionResult Index()
        {
            List<Product> productList = db.Products.ToList();
            return View (productList);
        }
        public IActionResult Buy(int Id)
        {
            Product p = db.Products.Find(Id);
            return View(p);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Result(Product p)
        {
            if (p.Quantity > 0)
            {
                p.Quantity = (int)p.Quantity - 1;
                db.Products.Update(p);
                db.SaveChanges();
            }

            return View(p);
        }

    }

}
