using System.Web.Mvc;

namespace Shop.Controllers
{
    public class NewsController : BaseController
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            return View();
        }

    }
}
