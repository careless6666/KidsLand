using KidsLand.Models.EF;
using KidsLand.Models.ViewModels;

namespace KidsLand.Controllers
{
    public interface ICustomMapping
    {
        NewsViewModel NewsToNewsViewModel(NewsViewModel nvm, News n);
    }
}
