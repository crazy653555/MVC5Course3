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
        // GET: EF
        public ActionResult Index(String searchProduct)
        {
            var db = new FabricsEntities();
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
                    Price = 1,
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
    }
}