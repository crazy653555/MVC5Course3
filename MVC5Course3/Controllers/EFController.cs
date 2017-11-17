using MVC5Course3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course3.Controllers
{
    public class EFController : Controller
    {
        // GET: EF
        public ActionResult Index()
        {
            var db = new FabricsEntities();

            db.Product.Add(new Product()
            {
                ProductName = "尾椎小太陽",
                Price = 5,
                Stock = 1,
                Active = true
            });

            db.SaveChanges();

            var data = db.Product.ToList();

            return View(data);
        }
    }
}