using System;
using System.Security.Cryptography;
using System.Text;

namespace FileSplit
{
    public class Hash
    {
        public static string Hex64Hash(string name)
        {
            var hashed = SHA256.HashData(UTF8Encoding.UTF8.GetBytes(name));
            return System.Convert.ToHexString(hashed);
        }
    }
}