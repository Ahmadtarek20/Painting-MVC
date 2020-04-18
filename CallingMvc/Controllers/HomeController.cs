using CallingMvc.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallingMvc.Controllers
{
    public class HomeController : Controller
    {
        DataContextDB dataContextDB = new DataContextDB();

       // [RequireHttps]
       // [OutputCache(CacheProfile = "1MinuteCahing")] //de 5asa bel looding Threding
        public ActionResult Index(string searchby, string Search, int? page, string sortby)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortby) ? "Name desc" : "";
            ViewBag.SortDesParameter = sortby == "Description" ? "Description desc" : "Description";

            var pro = dataContextDB.Products.AsQueryable();
            if (searchby == "Description")
            {
                pro = pro.Where(s => s.Description == Search || Search == null); //.ToList().ToPagedList(page ?? 1, 3);
            }
            else
            {

                pro = pro.Where(s => s.Name.StartsWith(Search) || Search == null); //.ToList().ToPagedList(page ?? 1, 3);
            }
            switch (sortby)
            {
                case "Name desc":
                    pro = pro.OrderByDescending(x => x.Name);
                    break;
                case "Description desc":
                    pro = pro.OrderByDescending(x => x.Description);
                    break;
                case "Description ":
                    pro = pro.OrderBy(x => x.Description);
                    break;
                default:
                    pro = pro.OrderBy(x => x.Name);
                    break;
            }
            return View(pro.ToPagedList(page ?? 1, 3));


        }


    }
}