using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using Calabonga.Mvc.Extensions;

namespace KidsLand.Controllers
{
    public class RssController : Controller
    {
        // GET: Rss
        public RssResult GetFeeds()
        {
            var si = new SyndicationItem
            {
                Title = new TextSyndicationContent("Заголовок1"),
                Content = new TextSyndicationContent("Содержимое фида1"), 
                BaseUri = new Uri(string.Format("http://www.calabonga.com/museum/show/{0}","1","1", DateTimeOffset.Now))
            };

            var di = new SyndicationItem
            {
                Title = new TextSyndicationContent("Заголовок2"),
                Content = new TextSyndicationContent("Содержимое фида2"),
                BaseUri = new Uri(string.Format("http://www.calabonga.com/museum/show/{0}", "2", "2", DateTimeOffset.Now))
            };

            var lsi = new List<SyndicationItem> {si, di};

            var ItemsList = lsi as IEnumerable<SyndicationItem>;

            var feed0 = new SyndicationFeed(
            "Музей Юмора - случайные",
            "Случайные поступления в музей юмора",
            new Uri("http://www.calabonga.com/site/rss/"),
            "calabongaCom0",
            DateTime.Now);
                    feed0.Generator = "ASP.NET MVC site";
                    feed0.ImageUrl = new Uri("http://www.calabonga.com/content/images/32x32.jpg");
                    feed0.Items = ItemsList;
            return new RssResult(feed0);
        }
        public static string CutLongText(string text, int maxLength, string appendText)
        {
            var result = string.Empty;

            return result;
        }
    }
}