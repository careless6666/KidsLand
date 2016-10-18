using System.Web;
using KidsLand.Models.EF;
using KidsLand.Models.ViewModels;

namespace KidsLand.Controllers
{
    public class CustomMapping : ICustomMapping
    {
        public NewsViewModel NewsToNewsViewModel(NewsViewModel nvm, News n)
        {
            nvm.NewsBody = n.NewsBody;
            nvm.NewsId = n.NewsId;
            nvm.NewsDate = n.NewsDate;
            nvm.NewsImgStr = n.NewsImg;
            nvm.NewsTitle = n.NewsTitle;
            nvm.News = new News()
            {
                NewsBody = n.NewsBody,
                NewsDate = n.NewsDate,
                NewsId = n.NewsId,
                NewsImg = n.NewsTitle
            };
            return nvm;
        }
    }
}