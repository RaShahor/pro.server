using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Security.Cryptography;

using Aspose.Pdf.Facades;

namespace BL
{
    public class LogInBL:IlogInBL
    {
        ILogInDL ILogIn;
        const int iterations=10000;
        const byte keySize = 64;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public  LogInBL(ILogInDL iLogIn)
        {
            this.ILogIn = iLogIn;
        }
        public async Task<User> postUser(string email, string psw)
        {
            User u=await ILogIn.PostExistingUser(email);
            if (Support.compareHashed(u.Person.Password, psw, u.Person.Salt))
                return u;
            return null;
        }

      

        public async Task<User> postUser(User user)
        {
            return await ILogIn.PostNewUser(user);
        }

        //public async void PutUser(string email, User user)
        //{
        //    user.Person.Mail = email;
        //    ILogIn.PutUser(email, user);
        //}

        public async Task putUser(string mail, User curUser)
        {
            curUser.Person.Mail = mail;
            await ILogIn.PutUser(mail, curUser);
        }



        //Task<List<User> >IlogInBL.GetUser(string mail, string password)
        //{
        //    throw new NotImplementedException();
        //}
      
        //string HashPasword(string password, out byte[] salt)
        //{
        //    salt = RandomNumberGenerator.GetBytes(keySize);
        //    var hash = Rfc2898DeriveBytes.Pbkdf2(
        //        Encoding.UTF8.GetBytes(password),
        //        salt,
        //        iterations,
        //        hashAlgorithm,
        //        keySize);
        //    return Convert.ToHexString(hash);
        //}
//        bool VerifyPassword(string password, string hash, byte[] salt)
//{
//            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
//            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
//        }
    }
}
