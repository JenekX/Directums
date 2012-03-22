using System;
using System.Text;
using System.Security.Cryptography;

namespace Directums.Classes.Core
{
    public static class HashHelper
    {
        public static string StringHash(string value)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static bool CompareHash(string value, string hash)
        {
            string hashValue = StringHash(value);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashValue, hash) == 0;
        }
    }
}