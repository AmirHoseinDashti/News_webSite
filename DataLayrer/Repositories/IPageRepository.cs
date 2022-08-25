using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayrer
{
    public interface IPageRepository:IDisposable
    {
        IEnumerable<Page> GetAllPage();
        Page GetPageById(int pageId);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(int pageId);
        void Save();

        IEnumerable<Page> TopNews(int take = 6);
        IEnumerable<Page> PagesInSlider();
        IEnumerable<Page> LastNews(int teke = 6);
        IEnumerable<Page> ShowPageByGroupId(int groupId);
        IEnumerable<Page> SearchPage(string Search);
    }
}
