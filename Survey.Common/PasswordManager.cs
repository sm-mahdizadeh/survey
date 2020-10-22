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
            var hash = (password + ConstSalt + salt).GetHashCode().ToString();

            return (hash, salt);
        }
        public static bool Verify(string password, string hash,string salt)
        {
            return (password + ConstSalt + salt).GetHashCode().Equals(hash);
        }
    }
}
