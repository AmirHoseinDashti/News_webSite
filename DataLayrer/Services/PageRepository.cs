using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayrer
{
    public class PageRepository:IPageRepository
    {
        private My_SiteContext db;

        public PageRepository(My_SiteContext context)
        {
            this.db = context;
        }

        public IEnumerable<Page> GetAllPage()
        {
            return db.Pages;
        }

        public Page GetPageById(int pageId)
        {
            return db.Pages.Find(pageId);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                db.Pages.Add(page);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool UpdatePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeletePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeletePage(int pageId)
        {
            try
            {
                var page = GetPageById(pageId);
                DeletePage(page);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Page> TopNews(int take = 6)
        {
            return db.Pages.OrderByDescending(p => p.Visit).Take(take);
        }

        public IEnumerable<Page> PagesInSlider()
        {
            return db.Pages.Where(p => p.ShowInSlider == true);
        }

        public IEnumerable<Page> LastNews(int teke = 6)
        {
            return db.Pages.OrderByDescending(p => p.CreateDate).Take(teke);
        }

        public IEnumerable<Page> ShowPageByGroupId(int groupId)
        {
            return db.Pages.Where(p => p.GroupID == groupId);
        }

        public IEnumerable<Page> SearchPage(string Search)
        {
            return
                db.Pages.Where(
                    p =>
                        p.Title.Contains(Search) || p.ShortDescription.Contains(Search) || p.Tags.Contains(Search) ||
                        p.Text.Contains(Search)).Distinct();
        }
    }
}
