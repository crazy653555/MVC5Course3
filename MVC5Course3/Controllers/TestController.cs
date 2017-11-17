using MVC5Course3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course3.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult MemberProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberProfile(MemberViewModel data)
        {
            return View();
        }
    }
}