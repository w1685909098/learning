using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
    public static class MD5Extension
    {
        public static string MD5Encrypt(this string source)
        {
            byte[] bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(source+"selfLearn编程&#.."));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
