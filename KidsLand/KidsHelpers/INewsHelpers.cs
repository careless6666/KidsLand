using System.Collections.Generic;
using KidsLand.Models.EF;

namespace KidsLand.KidsHelpers
{
    public interface INewsHelpers
    {
        PagedList.IPagedList<News> SetLength(PagedList.IPagedList<News> nl);
    }
}
