using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public static class Support
        
    {
        static readonly int LEN = 10;
        public static bool compareHashed(string password, string psw, string salt)
        {
            string hashed = GetHash(psw, salt);
            if (hashed == password)
                return true;
            return false;
        }
        public static string GetHash(string password, string salt)
        {
            salt = salt.TrimEnd();
            //int ctr = Encoding.Unicode.GetByteCount(String.Concat(salt, password));
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(salt, password));

            SHA512Managed sha512 = new SHA512Managed();
            byte[] hashedBytes = sha512.ComputeHash(unhashedBytes);
            string hashed_string = Encoding.ASCII.GetString(hashedBytes);
            //byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(salt, password));
            //byte[] unhashedBytes = Encoding.UTF8.GetBytes(String.Concat(salt, password));

            //SHA512Managed sha512 = new SHA512Managed();
            //byte[] hashedBytes = sha512.ComputeHash(unhashedBytes);
            //string hashed_string = Convert.ToBase64String(hashedBytes);
            return hashed_string;
        }
        private static string hash(string psw, string salt, int nIterations = 20, int nHash = 4)
        {

            char[] tmp = psw.ToCharArray();
            byte[] tmp1 = new byte[tmp.Length];
            int i = 0;
            foreach (char c in tmp)
            {
                tmp1[i++] = ((byte)c);
            }
            char[] tmp4 = salt.ToCharArray();
            byte[] tmp2 = new byte[tmp4.Length];
            i = 0;
            foreach (char c in tmp4)
            {
                tmp2[i++] = ((byte)c);
            }
            //var saltBytes = Convert.FromHexString(salt);
            //Iteration count is the number of times an operation is performed
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(tmp1, tmp2, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }

        }
    }
}
