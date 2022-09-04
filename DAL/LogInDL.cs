﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace DAL
{
    public class LogInDL : ILogInDL
    {
        SignContext myContext;

        ILogger logger;


        public LogInDL(SignContext myC)
        {
            myContext = myC;

            this.logger = logger;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await myContext.Users.ToListAsync();
        }
        public async Task<User> PostUser(string email, string pwd)
        {
            User p = await myContext.Users.Where(x => x.Person.Mail == email && x.Person.Password == pwd).Include(x => x.Person).
                 FirstAsync();
            return p;

        }

        public async Task<User> PostUser(User user)
        {
            await myContext.People.AddAsync(user.Person);
            await myContext.Users.AddAsync(user);
            await myContext.SaveChangesAsync();
            //await?
            return user;
        }

        public async Task<User> PutUser(string email, User user)
        {
            //var userToUpdate = await myContext.People.FindAsync(user.Id);
            ////myContext.Users.AddAsync(user);
            
            //if (userToUpdate == null)
            //    return null;
            //user.Person.Mail = email;
            //string Mail = email;
            //myContext.Entry(userToUpdate).CurrentValues.SetValues(Mail);
            await myContext.Users.Update(user).GetDatabaseValuesAsync();
             myContext.SaveChangesAsync();


            return user;

        }

    }
}
