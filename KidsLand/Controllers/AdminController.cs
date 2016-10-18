using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace KidsLand.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}