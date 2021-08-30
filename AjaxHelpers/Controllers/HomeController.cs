using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxHelpers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult LoadData()
        {
            List<string> listData = new List<string>() { "apple", "samsung", "xiaomi", "huawei", "general mobile", "sony"};

            return PartialView("_DataListPartialView", listData);
        }
    }
}