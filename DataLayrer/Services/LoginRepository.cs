using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayrer
{
    public class LoginRepository : ILoginRepository
    {
        private My_SiteContext db;

        public LoginRepository(My_SiteContext context)
        {
            db = context;
        }
        public bool IsExistUser(string username, string password)
        {
            return db.AdminLogins.Any(u => u.UserName == username && u.Password == password);
        }
    }
}
