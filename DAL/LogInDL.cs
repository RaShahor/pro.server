using Entities;
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


        public LogInDL(SignContext myC,ILogger<LogInDL>logger)
        {
            myContext = myC;

            this.logger = logger;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await myContext.Users.ToListAsync();
        }
        public async Task<User> PostExistingUser(string email, string pwd)
        {
            User p = await myContext.Users.Where(x => x.Person.Mail == email && x.Person.Password == pwd).Include(x => x.Person).
            FirstAsync();
            return p;

        }

        public async Task<User> PostNewUser(User user)
        {
            await myContext.People.AddAsync(user.Person);
            await myContext.Users.AddAsync(user);
            await myContext.SaveChangesAsync();
            //await?
            return user;
        }

        public async Task<User> PutUser(string email, User user)
        {
            //I deleted another update option
            await myContext.Users.Update(user).GetDatabaseValuesAsync();
            myContext.SaveChangesAsync();
            return user;
        }

    }
}
