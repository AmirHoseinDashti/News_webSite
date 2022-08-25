using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayrer;

namespace DataLayrer
{
    public class PageCommentRepository : IPageCommentRepository
    {
        private My_SiteContext db;

        public PageCommentRepository(My_SiteContext context)
        {
            db = context;
        }
        public bool AddComment(PageComment comment)
        {
            try
            {
                db.PageComments.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<PageComment> GetCommentByNewsId(int pageId)
        {
            return db.PageComments.Where(c => c.PageID == pageId);
        }
    }
}
