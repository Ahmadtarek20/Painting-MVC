using CallingMvc.Data;
using CallingMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallingMvc.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        DataContextDB dataContextDB = new DataContextDB();

        public ActionResult Index()
        {
            List<Category> category = dataContextDB.Categorys.ToList();
            return View(category);
        }
        public ActionResult Detiles(int id)
        {
            Category category = dataContextDB.Categorys.Single(cat => cat.CareguryId == id);
            return View(category);
        }
        public ActionResult Creat()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Creat(Category category)
        {
            if (dataContextDB.Categorys.Any(x => x.Categury_Name == category.Categury_Name))
            {  //de bawzt fekrt el MVC 
                ModelState.AddModelError("Categury_Name", "Name is rely esest");
            }
            dataContextDB.Categorys.Add(category);
            dataContextDB.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (dataContextDB.Carts.Any(x => x.ProductId == id))
            {  //de bawzt fekrt el MVC 
                ModelState.AddModelError("Product", "Name is rely esest");
            }
            Category categorydelete = dataContextDB.Categorys.Single(cat => cat.CareguryId == id);
            dataContextDB.Categorys.Remove(categorydelete);
            dataContextDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}