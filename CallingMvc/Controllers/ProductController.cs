using CallingMvc.Data;
using CallingMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CallingMvc.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DataContextDB dataContextDB = new DataContextDB();
        public ActionResult Index(int CategoryId)
        {
            DataContextDB dataContextDB = new DataContextDB();
            List<Product> product = dataContextDB.Products.Where(emp => emp.CategoryId == CategoryId).ToList();
            return View(product);
        }
        // [ChildActionOnly]
        public ActionResult Detiles(int id)
        {
            DataContextDB dataContextDB = new DataContextDB();
            Product product = dataContextDB.Products.Single(cat => cat.ProductId == id);
            return View(product);
        }
        [HttpGet]
        public ActionResult Creat()
        {

            return View();
        }
       
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Creat(Product product)
        {


            if (dataContextDB.Products.Any(x=>x.Name == product.Name))
              {  //de bawzt fekrt el MVC 
                  ModelState.AddModelError("Name", "Name is rely esest");
              }
            
          
            dataContextDB.Products.Add(product);
            dataContextDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit(int id)
        {
            DataContextDB dataContextDB = new DataContextDB();
            Product productedit = dataContextDB.Products.Single(cat => cat.ProductId == id);

            return View(productedit);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit(int? id)
        {
            DataContextDB dataContextDB = new DataContextDB();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var EdietProduct = dataContextDB.Products.Find(id);
            if (TryUpdateModel(EdietProduct, "",
               new string[] { "Name", "Description", "Price" }))
            {
                try
                {
                    dataContextDB.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                catch (RetryLimitExceededException)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(EdietProduct);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            DataContextDB dataContextDB = new DataContextDB();
            Product productdelet = dataContextDB.Products.Single(cat => cat.ProductId == id);
            dataContextDB.Products.Remove(productdelet);
            dataContextDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}