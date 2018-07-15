using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UTTTServer
{
    class SignGenerator
    {
        private static string key = "UTTT";
        public static string GetSign(string text)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] hash = provider.ComputeHash(Encoding.Default.GetBytes(text + key));

            return BitConverter.ToString(hash).ToLower().Replace(";", "").Replace("-", "");
        }
    }
}
