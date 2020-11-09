using System;
using System.Security.Cryptography;
using System.Text;

namespace Survey.Application.Utilites
{
    public  class PasswordUtility:IPasswordUtility
    {
        readonly string _constSalt = "@";
        public PasswordUtility()
        {

        }
        public PasswordUtility(string constSalt)
        {
            _constSalt = constSalt;
        }
        public  (string hash, string salt) Hash(string password)
        {
            var salt = new Random(DateTime.Now.Millisecond).Next().ToString();
            var hash = GetHash(password, salt,_constSalt);
          
            return (hash, salt);
        }
        public  bool Verify(string password, string hash, string salt)
        {
            return GetHash(password, salt,_constSalt).Equals(hash);
        }
        private static string GetHash(string password, string salt,string constSalt) {
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(Encoding.ASCII.GetBytes (password + constSalt + salt));
            return Encoding.ASCII.GetString( sha1data);

    } 
    }
}
