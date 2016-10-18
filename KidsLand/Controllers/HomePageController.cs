using System.Linq;
using System.Web.Mvc;
using KidsLand.Models.EF;
using KidsLand.Models.ViewModels;
using NLog;

namespace KidsLand.Controllers
{
    public class HomePageController : Controller
    {
        public static readonly Logger logger = LogManager.GetCurrentClassLogger();
        //
        // GET: /HomePage/
        public ActionResult Index()
        {
            logger.Info("Look home page");
            var mpvm = new MainPageViewModel();
            var context = new KidsLandIdentityContext();
            mpvm.NewsList = context.News.OrderByDescending(x => x.NewsDate).Take(2).ToList();
            return View(mpvm);
        }
	}
}