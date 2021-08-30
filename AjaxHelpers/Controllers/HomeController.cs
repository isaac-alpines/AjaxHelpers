using AjaxHelpers.Models;
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
            List<TodoItem> list;

            if (Session["listData"] != null)
            {
                list = Session["listData"] as List<TodoItem>;
            }
            else
            {
                list = new List<TodoItem>();
            }

            ViewBag.List = list;

            return View(new TodoItem());
        }

        [HttpPost]
        public PartialViewResult Index(TodoItem model)
        {
            List<TodoItem> list = null;

            if (Session["listData"] != null)
            {
                list = Session["listData"] as List<TodoItem>;
            } 
            else
            {
                list = new List<TodoItem>();
            }

            model.Id = Guid.NewGuid();

            list.Add(model);

            Session["listData"] = list;

            return PartialView("_DataListPartialView", model);
        }

        public PartialViewResult LoadData()
        {
            List<TodoItem> listData = null;

            if (Session["listData"] != null)
            {
                listData = Session["listData"] as List<TodoItem>;
            }
            else
            {
                listData = new List<TodoItem>();
            }

            System.Threading.Thread.Sleep(1000);

            return PartialView("_DataListPartialView", listData);
        }

        public MvcHtmlString RemoveData(Guid id)
        {
            List<TodoItem> listData = Session["listData"] as List<TodoItem>;

            foreach (TodoItem item in listData)
            {
                if (item.Id == id)
                {
                    listData.Remove(item);
                    break;
                }
            }

            Session["listData"] = listData;

            System.Threading.Thread.Sleep(500);

            return MvcHtmlString.Empty;
        }
    }
}