using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FormDL: IFormDL
    {
        SignContext myContext;
        public FormDL(SignContext myC)
        {
            myContext = myC;
        }
        public async Task<List<FormToSigner>> getAllFormsToUserBySigner(int us)
        {

            List<FormToSigner> FTS = await myContext.FormToSigners
                    .Where(x => (x).Form.UserId == us)
                    .ToListAsync();
            return FTS;

        }
        public async Task<List<FormTemplate>> getAllFormsTemplatesByUser(int id)
        {
             var FT = await myContext.FormTemplates
                    .Where(x => x.FormUser.UserId == id)
                    //.ThenInclude(f => ((FormUser)f).UserId == id)
                    .ToListAsync();

            return FT;

        }
        public async Task<List<FormToSigner>> getAllFormsToSignerByUserIdAndSignerId(int idu, int ids)
        {

            List<FormToSigner> UTS = await myContext.FormToSigners
                   .Where(x => x.Form.UserId == idu && x.SignerId == ids)

                   .ToListAsync();
            return UTS;

        }
        public async Task<FormToSigner> newFTS(FormToSigner fts)
        {

            await myContext.FormToSigners.AddAsync(fts);
            await myContext.SaveChangesAsync();
            FormToSigner addedSuccessfully = await myContext.FormToSigners.Where(x => x.FormId == fts.FormId && x.SignerId == fts.SignerId).FirstAsync();
            return addedSuccessfully;
        }
        public async void updateStatusOfFTS(int id1, FormToSigner fts)
        {
            //await myContext.FormToSigners.Update((FormToSigner)myContext.FormToSigners.Where(x=>x.Id==id1));
            myContext.FormToSigners.Update(fts);
            myContext.SaveChanges();

        }
        public int getSignersNumberToForm(int id)
        {
            return myContext.FormUsers.Find(id).NumOfSigners;
        }
        public async Task<FormUser> GetUserForm(int userId, string fileName)
        {
            return await myContext.FormUsers.Where(f => f.UserId == userId && f.FormName == fileName).FirstAsync();
        }

        public bool SaveUserForm(FormUser newForm)
        {
            myContext.FormUsers.Add(newForm);
            int i = myContext.SaveChanges();
            if (i < 1)
                return false;
            return true;
        }

        public async Task<FormTemplate> getFT(string name, int id)
        {
            //logger.LogWarning("error 500? but logger works!!!");
            return myContext.FormTemplates.Where(ft => ft.Description == name&&ft.FormUser.UserId==id).FirstOrDefault();

        }
        
    }
}
