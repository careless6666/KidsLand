using System.Web.Mvc;
using KidsLand.Models;
using KidsLand.Models.EF;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KidsLand.Controllers.AboutUs
{
    public class TeachersController : Controller
    {
        // GET: Teachers
        public ActionResult TeachersIndex()
        {
            var store = new UserStore<ApplicationUser>(new KidsLandIdentityContext()) { AutoSaveChanges = false };
            
            return View("~/Views/AboutUs/TeacherView.cshtml");
        }
    }
}