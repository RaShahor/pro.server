using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Security.Cryptography;

namespace BL
{
    public class LogInBL:IlogInBL
    {
        ILogInDL ILogIn;
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
    }
}
