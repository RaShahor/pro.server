using DAL;
using Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FormBL : IformBL
    {
        //?private readonly IuserFor_managerDL userFor_managerDL;
        private IFormDL _formDL;
        private ILogger _logger;
        
        public FormBL( IFormDL formDL,ILogger<FormBL>log)
        {
           //? userFor_managerDL = iuserFor_managerDL;IuserFor_managerDL iuserFor_managerDL,
            _formDL = formDL;
            _logger = log;
        }

        public int getSignersNumberToForm(int id)
        {
            return _formDL.getSignersNumberToForm(id);
        }

        public Task<FormUser> GetUserForm(int userId, string fileName)
        {
            return _formDL.GetUserForm(userId, fileName);
        }

        public bool SaveForm(FormUser newForm)
        {
            return _formDL.SaveUserForm(newForm);
        }

        public Task<List<FormToSigner>> getAllFormsToUserBySigner(int id)
        {
            return _formDL.getAllFormsToUserBySigner(id);
        }

        public Task<List<FormTemplate>> getAllFormsTemplatesByUser(int id)
        {
            return _formDL.getAllFormsTemplatesByUser(id);
        }

        public Task<List<FormToSigner>> getAllFormsToSignerByUserIdAndSignerId(int idu, int ids)
        {
            return _formDL.getAllFormsToSignerByUserIdAndSignerId(idu,ids);
        }
        public async Task<FormToSigner> newFTS(FormToSigner form)
        {
            //FormToSigner fts = new FormToSigner() { SignerId = sId, FormId = form.Id, Class = cls, Status = status, Order = (byte?)order };
            return await _formDL.newFTS(form);
        }
        public async Task updateStatusOfFTS(int status, FormToSigner fts)
        {
            fts.Status = status;//update status
            _formDL.updateStatusOfFTS(status, fts);
            _logger.LogInformation("we updated bsd status of" + fts.SignerId + " to be " + status);
        }

        public async Task<FormTemplate> getFT(string name, int id)
        {
            return await _formDL.getFT(name, id);
        }
    }
}
