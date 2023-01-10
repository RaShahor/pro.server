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
        public async Task<User> PostExistingUser(string email)
        {
            User p = await myContext.Users.Where(x => x.Person.Mail == email ).Include(x => x.Person).
            FirstAsync();
            
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
       

        

        //private static bool CompareHash(string attemptedPassword, byte[] hash, string salt)
        ////is password after hashing with salt the same as user`s hash in DB?
        //{
        //    string base64Hash = Convert.ToBase64String(hash);
        //    string base64AttemptedHash = Convert.ToBase64String(GetHash(attemptedPassword, salt));

        //    return base64Hash == base64AttemptedHash;
        //}
        public async Task<User> PostNewUser(User user)
        {
            user.Person.Salt = generateSalt();
            user.Person.Password = Support.GetHash(user.Person.Password, user.Person.Salt);
            await myContext.People.AddAsync(user.Person);
            await myContext.Users.AddAsync(user);
            await myContext.SaveChangesAsync();
            //await?
            return user;
        }
        public static string hash(string psw, string salt, int nIterations = 20, int nHash = 4)
        {
            char[]tmp = psw.ToCharArray();
            byte[] tmp1 = new byte[tmp.Length];
            int i = 0;
            foreach( char c in tmp)
            {
                tmp1[i++] = ((byte)c);
            }
            char[]tmp4 = salt.ToCharArray();
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
        private string generateSalt()
        {
            string salt = "";
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                salt += (char)(rnd.Next(97,123));
            }
           
            return salt;
        }

        public async Task<User> PutUser(string email, User user)
        {
            //I deleted another update option
            await myContext.Users.Update(user).GetDatabaseValuesAsync();
            await myContext.SaveChangesAsync();
            return user;
        }

    }
}
