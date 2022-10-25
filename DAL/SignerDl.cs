using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SignerDl:ISignerDl
    {
        private readonly SignContext _ctx;
        public SignerDl(SignContext scon)
        {
            this._ctx = scon;
        }
        public async Task<Signer> getSignerById(int signer)
        {
            return await _ctx.Signers.FindAsync(signer);
           

        }

        public async Task<Person> getPersonById(int p)
        {
            Person pers = await _ctx.People.FindAsync(p);
            return pers;
        }

        public string getPassword(string mail)
        {
            DateTime passTime = (DateTime)_ctx.Signers.Where(s => s.Person.Mail == mail).FirstOrDefault().PassTime;
            if (passTime.AddHours(24) > DateTime.Now)
                return _ctx.People.Where(p => p.Mail == mail).FirstOrDefault().Password;
            return generatePWD(mail);
        }

        private string generatePWD(string mail)
        {
            string pwd = "";
            Random rnd = new Random();
            for (int i=0; i < 6; i++)
            {
                pwd+=((char)(rnd.Next(106) + 20));
            }
            Signer cur = _ctx.Signers.Where(s => s.Person.Mail == mail).Include(s=>s.Person).FirstOrDefault();
            cur.Person.Password = pwd;
            cur.PassTime = DateTime.Now;
            _ctx.Signers.Update(cur);
            _ctx.SaveChanges();
            return pwd;
        }

        public DateTime getPassTime(string mail)
        {
            DateTime dt = (DateTime)_ctx.Signers.Where(s => s.Person.Mail == mail).FirstOrDefault().PassTime;
            return dt.AddDays(1);
        }
        //public async Task<bool> sendMail(int ftsId,Office office,int signer)
        //{




        //            }

    }
            }

       
 
