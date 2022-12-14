using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SignerDl:ISignerDl
    {
        private readonly SignContext myContext;
        public SignerDl(SignContext scon)
        {
            this.myContext = scon;
        }
        public async Task<Signer> getSignerById(int signer)
        {
            return await myContext.Signers.FindAsync(signer);
           

        }

        public async Task<Person> getPersonById(int p)
        {
            Person pers = await myContext.People.FindAsync(p);
            return pers;
        }

        public string getPassword(string mail)
        {
            DateTime passTime = (DateTime)myContext.Signers.Where(s => s.Person.Mail == mail).FirstOrDefault().PassTime;
            if (passTime.AddHours(24) > DateTime.Now)
                return myContext.People.Where(p => p.Mail == mail).FirstOrDefault().Password;
            return generatePWD(mail);
        }

        public string generatePWD(string mail)//Has to transfer to BL and change back to private!!
        {
            string pwd = "";
            Random rnd = new Random();
            for (int i=0; i < 6; i++)
            {
                pwd+=((char)(rnd.Next(106) + 20));
            }
            Signer cur = myContext.Signers.Where(s => s.Person.Mail == mail).Include(s=>s.Person).FirstOrDefault();
            cur.Person.Password = pwd;
            cur.PassTime = DateTime.Now;
            myContext.Signers.Update(cur);
            myContext.SaveChanges();
            return pwd;
        }
        
        public DateTime getPassTime(string mail)
        {
            DateTime dt = (DateTime)myContext.Signers.Where(s => s.Person.Mail == mail).FirstOrDefault().PassTime;
            return dt.AddDays(1);
        }

        public async Task<List<Signer>> getAllSignersByUser(int id)
        {

            var SIGNERS = myContext.Signers
                        .Where(x => x.UserId == id).Include(s => s.Person)
                        .ToList();
            return SIGNERS;

        }

        public async Task<Signer> newSigner(Signer signer, int Uid = 1)
        {
            //SignContext con = new SignContext();
            var u = myContext.Users.Find(Uid);
            // myContext.Users.איך מוסיפים לתוך מסד הנתונים?
            if ((User)u != null)
                ((User)u).Signers.Add(signer);//
            await myContext.Signers.AddAsync(signer);
            await myContext.SaveChangesAsync();
            return signer;
        }
    }
}

       
 
