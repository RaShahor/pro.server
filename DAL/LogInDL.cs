using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;

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
            if (CompareHash(pwd,p.Person.Password.to,p.Person.Salt)
            return p;

        }
        public async Task<string[]>getHashedPasswordAndSaltFromDB(string email)
        {
            User u = await myContext.Users.Where(x => x.Person.Mail == email)
                .Include(u => u.Person.Password+u.Person.Salt)
                .FirstAsync();
            string[] res = { u.Person.Password, u.Person.Salt };
            return res;
        }
        public string HashPassword(string password, string salt, int nIterations, int nHash)
        {
            var saltBytes = Convert.FromBase64String(salt);
            //Iteration count is the number of times an operation is performed
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }
        }

        public static byte[] GetHash(string password, string salt)
        {
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(salt, password));

            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);

            return hashedBytes;
        }

        private static bool CompareHash(string attemptedPassword, byte[] hash, string salt)
        //is password after hashing with salt the same as user`s hash in DB?
        {
            string base64Hash = Convert.ToBase64String(hash);
            string base64AttemptedHash = Convert.ToBase64String(GetHash(attemptedPassword, salt));

            return base64Hash == base64AttemptedHash;
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
