using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Microsoft.Data.SqlClient;

//using Microsoft.Extensions.Logging;
namespace DAL
{
    public class ManagerDL : IManagerDL
    {
        SignContext myContext;
       
        ILogger<ManagerDL> logger;


        public ManagerDL( SignContext myC,ILogger<ManagerDL> logger)
        { 
            myContext = myC;
           
            this.logger = logger;
        }

        public async Task DeleteformsToSigner_rangeAsync(int id, DateTime date)
        {
            Task<List<FormSigner>> removings = myContext.FormSigners.Where(x => x.Date < date).ToListAsync();

            foreach (FormSigner item in removings.Result)
            {
                int formId = (int)item.FormTosigner.FormId;
                myContext.FormSigners
                    .RemoveRange(myContext.FormSigners
                    .Include(FS => FS.FormTosigner)
                    .ThenInclude(FTS => FTS.FormId == formId));
            }
        }

        public async Task DeleteformsToUser_range(int id, DateTime date)
        {
            myContext.FormToSigners.RemoveRange();
            //TODO  
            //have to think what to do with range - add date to db or stng else!
        }

        public async Task DeleteSigner(int id)
        {
            Signer s = myContext.Signers.Find(id);
            //Error = Cannot evaluate expression because a thread is stopped at a point where garbage collection is impossible, possibly because the code is optimized.
            //if(s!=null)
            myContext.Signers.Remove(s);
            myContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            User u = (User)myContext.Users.Find(id);
            myContext.Users.Remove(u);
            myContext.SaveChanges();
        }
        //Error://(Convert(f, FormUser).UserId == __id_0)' is invalid inside an 'Include' operation, since it does not represent a property access: 
        //'t => t.MyProperty'. To target navigations declared on derived types, use casting ('t => ((Derived)t).MyProperty')
        //public async Task<List<FormTemplate>> getAllFormsTemplatesByUser(int id)
        //{


        //    var FT = await myContext.FormTemplates
        //            .Where(x => x.FormUser.UserId==id)
        //            //.ThenInclude(f => ((FormUser)f).UserId == id)
        //            .ToListAsync();

        //    return FT;

        //}

        public async Task<List<FormToSigner>> getAllFormsToSignerByUserIdAndSignerId(int idu, int ids)
        {

            List<FormToSigner> UTS = await myContext.FormToSigners
                   .Where(x => x.Form.UserId == idu && x.SignerId == ids)

                   .ToListAsync();
            return UTS;

        }


        public async Task<List<Signer>> getAllSignersByUser(int id)
        {

            var SIGNERS = myContext.Signers
                        .Where(x => x.UserId == id).Include(s=>s.Person)
                        .ToList();
            return SIGNERS;

        }

        public async Task<FormToSigner> newFTS(FormToSigner fts)
        {

            await myContext.FormToSigners.AddAsync(fts);
            await myContext.SaveChangesAsync();
            FormToSigner addedSuccessfully = await myContext.FormToSigners.Where(x => x.FormId == fts.FormId && x.SignerId == fts.SignerId).FirstAsync();
            return addedSuccessfully;
        }

        public async Task<Signer> newSigner(Signer signer, int Uid = 1)
        {
            //SignContext con = new SignContext();
            var u = myContext.Users.Find(signer.UserId);
            // myContext.Users.איך מוסיפים לתוך מסד הנתונים?
            if ((User)u != null)
                ((User)u).Signers.Add(signer);//
            await myContext.Signers.AddAsync(signer);
            await myContext.SaveChangesAsync();
            return signer;
        }

        public async void updateStatusOfFTS(int id1, FormToSigner fts)
        {
            //await myContext.FormToSigners.Update((FormToSigner)myContext.FormToSigners.Where(x=>x.Id==id1));
            myContext.FormToSigners.Update(fts);
            myContext.SaveChanges();

        }

        async Task IManagerDL.DeleteformsToSigner_rangeAsync(int id, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
                                                          
