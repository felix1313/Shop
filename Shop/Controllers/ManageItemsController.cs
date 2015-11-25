using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Filters;

namespace Shop.Controllers
{
	[AuthorizationFilter]
    public class ManageItemsController : BaseController
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
