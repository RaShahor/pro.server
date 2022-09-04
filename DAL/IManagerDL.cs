using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IManagerDL
    {
        Task<List<FormToSigner>> getAllFormsToUserBySigner(int id);
        Task<List<FormTemplate>> getAllFormsTemplatesByUser(int id);
        Task<List<Signer>> getAllSignersByUser(int id);
        Task<List<FormToSigner>> getAllFormsToSignerByUserIdAndSignerId(int idu, int ids);
        Task<Signer> newSigner(Signer signer, int UId);
        Task<FormToSigner> newFTS(FormToSigner fts);
        void updateStatusOfFTS(int id1, FormToSigner fts);
        Task DeleteSigner(int id);
        Task DeleteformsToSigner_rangeAsync(int id, DateTime date);
        Task DeleteUser(int id);
        Task DeleteformsToUser_range(int id, DateTime date);
    }
}