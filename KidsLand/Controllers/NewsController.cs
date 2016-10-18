using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidsLand.KidsHelpers;
using KidsLand.Mappers;
using KidsLand.Models.EF;
using KidsLand.Models.ViewModels;
using Ninject;
using NLog;
using PagedList;

namespace KidsLand.Controllers
{
    public class NewsController : Controller
    {
        public static readonly Logger logger = LogManager.GetCurrentClassLogger();
        [Inject]
        public IMapper ModelMapper { get; set; }
        [Inject]
        public ICustomMapping CustomMapper { get; set; }
        [Inject]
        public INewsHelpers NewHelp { get; set; }


        // GET: News
        public ActionResult News(int? page)
        {
            var nl = new NewsViewModel();
            var context = new KidsLandIdentityContext();
            nl.NewsListPages = context.News.OrderByDescending(x=>x.NewsDate).ToList().ToPagedList(page ?? 1,4);
            NewHelp.SetLength(nl.NewsListPages);
            return View(nl.NewsListPages);
        }

        public ActionResult GetNews(string str)
        {
            try
            {
                var id = Convert.ToInt32(str);
                var nl = new NewsViewModel();
                var context = new KidsLandIdentityContext();
                nl.News = context.News.Single(x => x.NewsId == id);
                return View("~/Views/News/CurrentNews.cshtml", nl);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public ActionResult CreateNews()
        {
            return View("~/Views/News/CreateNews.cshtml");
        }

        public ActionResult SaveNews(NewsViewModel n)
        {
            var imgSrc = "";
            var time = DateTime.Now.ToString().Replace(".","");
            time = time.Replace(":", "");
            if (n.NewsImg == null)
            {
                imgSrc = Url.Content("~/Content/img/News/Default-img.jpg");
            }
            else
            {
                HttpPostedFileBase filebase =n.NewsImg;
                var filepath = Path.Combine(Server.MapPath("~/Content/img/News"), time + filebase.FileName);
                filebase.SaveAs(filepath);
                imgSrc = Url.Content("~/Content/img/News/" + time + filebase.FileName);
            }
            if (ModelState.IsValid)
            {
                var ns = (News) ModelMapper.Map(n, typeof (NewsViewModel), typeof(News));
                ns.NewsDate = DateTime.Now;
                ns.NewsImg = imgSrc;
                var context = new KidsLandIdentityContext();
                context.News.Add(ns);
                context.SaveChanges();
            }
            return RedirectToAction("News");
        }

        public ActionResult UpdateNews(NewsViewModel n)
        {
            try
            {
                var imgSrc = "";
                var time = DateTime.Now.ToString().Replace(".", "");
                time = time.Replace(":", "");
                if (n.NewsImg == null && String.IsNullOrEmpty(n.NewsImgStr))
                {
                    imgSrc = Url.Content("~/Content/img/News/Default-img.jpg");
                }
                else
                {
                    imgSrc = n.NewsImgStr;
                }
                if (ModelState.IsValid)
                {
                    var ns = (News)ModelMapper.Map(n, typeof(NewsViewModel), typeof(News));
                    ns.NewsDate = DateTime.Now;
                    ns.NewsImg = imgSrc;
                    var context = new KidsLandIdentityContext();
                    var del = context.News.First(x => x.NewsId == ns.NewsId);
                    context.News.Remove(del);
                    context.News.Add(ns);
                    context.SaveChanges();
                }
                return RedirectToAction("News");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            
            return null;
        }

        public ActionResult EditNews(FormCollection form)
        {
            try
            {
                var context = new KidsLandIdentityContext();
                int id = Convert.ToInt32(form["News.NewsId"].ToString());
                var nn = context.News.First(x => x.NewsId == id);
                var nl = new NewsViewModel();
                nl = CustomMapper.NewsToNewsViewModel(nl, nn);
                return View("~/Views/News/EditNews.cshtml",nl);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            return null;
        }
        
        public ActionResult RemoveNews(string id)
        {
            try
            {
                var context = new KidsLandIdentityContext();
                var Id = Convert.ToInt32(id);
                var n = context.News.First(x => x.NewsId == Id);
                context.News.Remove(n);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            return RedirectToAction("News");
        }
        
    }
}