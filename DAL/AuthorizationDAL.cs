using Entity.SearchIn;
using Entity.SearchOut;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DAL
{
    public class AuthorizationDAL
    {
        public static int AddOrUpdate(Entity.Authorization auth) {
            using (bdMyGameContext data = new bdMyGameContext()) {
                var dbuser = data.Users.FirstOrDefault(Item=>Item.Name == auth.Name);
                if (dbuser == null) {
                    dbuser = new User();
                    data.Users.Add(dbuser);
                }
                dbuser.Name = auth.Name;
                dbuser.Password = auth.HashPassword;
                dbuser.Total = auth.Total;

                data.SaveChanges();
                return dbuser.Id;
            }
        }

        public static SearchOutUser Get(SearchInUser searchIn)
        {
            SearchOutUser searchOut = new SearchOutUser();
            using (bdMyGameContext data = new bdMyGameContext())
            {
                var temp = data.Users.Where(Item => string.IsNullOrEmpty(searchIn.UserName) || Item.Name == searchIn.UserName);
                searchOut.Total = temp.Count();
                if (searchIn.Top.HasValue)
                {
                    temp = temp.Take(searchIn.Top.Value);
                }

                if (searchIn.Skip.HasValue)
                {
                    temp = temp.Skip(searchIn.Skip.Value);
                }

                searchOut.Users = temp.ToList().Select(Item => new Entity.Authorization()
                {
                    HashPassword = Item.Password,
                    Id = Item.Id,
                    Total = Item.Total,
                    Name = Item.Name
                }).ToList();
                searchOut.Count = temp.Count();
            }
            return searchOut;
        }

        public static Entity.Authorization Get(string login)
        {
            using (bdMyGameContext data = new bdMyGameContext())
            {
                var dbuser = data.Users.FirstOrDefault(Item => Item.Name == login);
                if (dbuser == null)
                {
                    return null;
                }
                var user = new Entity.Authorization();
                user.Name = dbuser.Name;
                user.HashPassword = dbuser.Password;
                user.Total = dbuser.Total;

                return user;
            }
        }
    }
}
