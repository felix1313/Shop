using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ManageItemsController : Controller
    {
        //
        // GET: /ManageItems/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult SubmitAdd()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}
