using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsLand.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interest
        public ActionResult InterestIndex()
        {
            return View();
        }
    }
}