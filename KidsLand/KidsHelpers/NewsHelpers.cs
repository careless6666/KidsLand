using System.Collections.Generic;
using KidsLand.Models.EF;

namespace KidsLand.KidsHelpers
{
    public class NewsHelpers : INewsHelpers
    {
        public PagedList.IPagedList<News> SetLength(PagedList.IPagedList<News> nl) 
        {
            const int titleLength = 100;
            const int bodyLength = 300;
            foreach (var newse in nl)
            {
                if (newse.NewsTitle.Length > titleLength)
                    newse.NewsTitle = newse.NewsTitle.Substring(0, titleLength) + " ...";
                if (newse.NewsBody.Length > bodyLength)
                    newse.NewsBody = newse.NewsBody.Substring(0, bodyLength) + " ...";
                
            }
            return nl;
        }
    }
}