using CallingMvc.Data;
using CallingMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallingMvc.Controllers
{
    public class CartsController : Controller
    {
        // GET: Carts
        DataContextDB dataContextDB = new DataContextDB();

        public ActionResult Index()
        {
            List<Carts> cart = dataContextDB.Carts.ToList();
            return View(cart);
        }
        [HttpPost]
        public ActionResult Add(int id)
        {
            if (ModelState.IsValid)
            {
                if (dataContextDB.Carts.Any(ac => ac.ProductId.Equals(id)))
                {
                    return RedirectToAction("Index", "Home");
                    ;
                }
                else
                {
                    Carts cartadd = dataContextDB.Carts.FirstOrDefault(car => car.ProductId == id);
                    var cartToAdd = new Carts()
                    { ProductId = id };
                    dataContextDB.Carts.Add(cartToAdd);
                    dataContextDB.SaveChanges();
                }
            }
            
            return RedirectToAction("Index", "Carts");
            
           
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
           
            Carts productdelet = dataContextDB.Carts.Single(cat => cat.ProductId == id);
            dataContextDB.Carts.Remove(productdelet);
            dataContextDB.SaveChanges();
            return RedirectToAction("Index", "Carts");
        }

    }
}