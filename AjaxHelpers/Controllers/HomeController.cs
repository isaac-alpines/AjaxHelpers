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
            List<string> listData = new List<string>() { "apple", "samsung", "xiaomi", "huawei", "general mobile", "sony" };

            Session["listData"] = listData;

            return View();
        }

        public PartialViewResult LoadData()
        {
            List<string> listData = Session["listData"] as List<string>;

            System.Threading.Thread.Sleep(1000);

            return PartialView("_DataListPartialView", listData);
        }

        public MvcHtmlString RemoveData(int? id)
        {
            List<string> listData = Session["listData"] as List<string>;

            listData.Remove(id.ToString());

            Session["listData"] = listData;

            System.Threading.Thread.Sleep(500);

            return MvcHtmlString.Empty;
        }
    }
}