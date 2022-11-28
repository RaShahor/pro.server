using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IformBL
    {
        public bool SaveForm(FormUser newForm);
        public Task<FormUser> GetUserForm(int userId, string fileName);
        int getSignersNumberToForm(int id);
        Task<List<FormToSignerDTO>> getAllFormsToUserBySigner(int id);
        Task<List<TemplateDTO>> getAllFormsTemplatesByUser(int id);
        Task<List<FormToSigner>> getAllFormsToSignerByUserIdAndSignerId(int idu, int ids);
        Task<FormToSigner> newFTS(FormToSigner form);
        Task updateStatusOfFTS(int status, FormToSigner fts);
        Task<FormTemplate> getFT(string name, int id);
    }
}