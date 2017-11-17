using MVC5Course3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course3.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index(String searchProduct)
        {
            var data = db.Product.AsQueryable();

            if (!string.IsNullOrEmpty(searchProduct))
            {
                data = data.Where(p => p.ProductName.Contains(searchProduct));
            }
            else
            {
                db.Product.Add(new Product()
                {
                    ProductName = "BMW",
                    Price = 2,
                    Stock = 1,
                    Active = true
                });


                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                    {
                        string entityName = item.Entry.Entity.GetType().Name;

                        foreach (DbValidationError err in item.ValidationErrors)
                        {
                            throw new Exception(entityName + " 類型驗證失敗: " + err.ErrorMessage);
                        }
                    }
                    throw;
                }
            }

            return View(data);
        }



        public ActionResult Detail(int id)
        {
            //var data = db.Product.Find(id);

            //var data = db.Product.Where(p => p.ProductId == id).FirstOrDefault();

            var data = db.Product.FirstOrDefault(p => p.ProductId == id);
            return View(data);
        }
    }
}