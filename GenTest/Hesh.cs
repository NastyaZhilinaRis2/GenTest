using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GenTest
{
    public static class Hesh
    {
        public static string HashPassword(string password)
        {
            MD5 mD5 = MD5.Create();
            byte[] b = Encoding.UTF8.GetBytes(password);
            byte[] hash = mD5.ComputeHash(b);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var a in hash)
            {
                stringBuilder.Append(a.ToString("X2"));
            }

            return Convert.ToString(stringBuilder);
        }
    }
}
