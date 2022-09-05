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
        //public async Task<bool> sendMail(int ftsId,Office office,int signer)
        //{
           


                
        //            }
                   
                }
            }

       
 
