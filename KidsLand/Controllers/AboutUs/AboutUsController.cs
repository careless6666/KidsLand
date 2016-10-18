using System.Web.Mvc;

namespace KidsLand.Controllers.AboutUs
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Documents()
        {
            return View("~/Views/AboutUs/Documents.cshtml");
        }

    }
}