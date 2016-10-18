using System.Web.Mvc;

namespace KidsLand.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult ContactsIndex()
        {
            return View();
        }
    }
}