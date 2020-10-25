using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common
{
    public static class PasswordManager
    {
        const string ConstSalt = "@";
        public static (string hash,string salt) Hash(string password)
        {
            var salt= new Random(DateTime.Now.Millisecond).Next().ToString();
            var hash = GetHash(password, salt);

            return (hash, salt);
        }
        public static bool Verify(string password, string hash,string salt)
        {
            return GetHash(password , salt).Equals(hash);
        }
        private static string GetHash(string password, string salt) => (password + ConstSalt + salt)/*.GetHashCode()*/.ToString();
    }
}
