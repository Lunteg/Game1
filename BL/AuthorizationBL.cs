using System;
using System.Security.Cryptography;
using System.Text;

namespace BL
{
    public class AuthorizationBL
    {
        private static SHA512 hashAlgo = SHA512.Create();
        private static byte[] GetStringHash(string s)
        {
            if (s == null)
                return null;
            byte[] hash = hashAlgo.ComputeHash(Encoding.Unicode.GetBytes(s));
            return hash;
        }
        public void Registration(Entity.Authorization auth)
        {
            auth.HashPassword = GetStringHash(auth.Password);
            DAL.AuthorizationDAL.AddOrUpdate(auth);
        }

        public bool Authorized(Entity.Authorization auth)
        {
            var user = DAL.AuthorizationDAL.Get(auth.Name);
            if (user == null)
                return false;
            return user.Password == auth.Password;
        }
        public void GetUsers(Entity.SearchIn.SearchInUser user)
        {
            DAL.AuthorizationDAL.Get(user);
        }
    }
}
