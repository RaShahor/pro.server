using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IFormDL
    {
        Task<List<FormToSigner>> getAllFormsToUserBySigner(int us);
        Task<List<FormTemplate>> getAllFormsTemplatesByUser(int id);
        Task<List<FormToSigner>> getAllFormsToSignerByUserIdAndSignerId(int idu, int ids);
        Task<FormToSigner> newFTS(FormToSigner fts);
        void updateStatusOfFTS(int id1, FormToSigner fts);
        int getSignersNumberToForm(int id);
        Task<FormUser> GetUserForm(int userId, string fileName);
        bool SaveUserForm(FormUser newForm);
    }
}
