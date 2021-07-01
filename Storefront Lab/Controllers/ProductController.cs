using Microsoft.AspNetCore.Mvc;
using Storefront_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storefront_Lab.Controllers
{
    public class ProductController : Controller
    {
        ProductDBContext db = new ProductDBContext();
        public IActionResult Index()
        {
            List<Product> productList = db.Products.ToList();
            return View(productList);
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        public IActionResult Details(int id)
        {
            Product p = db.Products.Find(id);
            return View(p);
        }
        public IActionResult Update(int id)
        {
            Product p = db.Products.Find(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult Update(Product p)
        {
            db.Products.Update(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        public IActionResult Delete(int Id)
        {
            Product p = db.Products.Find(Id);
            return View(p);
        }

        [HttpPost]
        public IActionResult Delete(Product p)
        {
            db.Products.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}
