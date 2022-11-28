using AutoMapper;
using DAL;
using DTO;
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
        private IMapper _mapper;

        public FormBL( IFormDL formDL,ILogger<FormBL>log,IMapper mapper)
        {
           //? userFor_managerDL = iuserFor_managerDL;IuserFor_managerDL iuserFor_managerDL,
            _formDL = formDL;
            _logger = log;
            _mapper = mapper;
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

        public async Task<List<FormToSignerDTO>> getAllFormsToUserBySigner(int id)
        {
            List<FormToSigner> fts =await _formDL.getAllFormsToUserBySigner(id);
            List<FormToSignerDTO>ftsDTOs=_mapper.Map<List<FormToSigner>,List<FormToSignerDTO>>(fts);
            return ftsDTOs;
        }

        public async Task<List<TemplateDTO>> getAllFormsTemplatesByUser(int id)
        {
            List<FormTemplate>ft=await _formDL.getAllFormsTemplatesByUser(id);
            List<TemplateDTO>ftDTOs=_mapper.Map<List<FormTemplate>,List<TemplateDTO>>(ft);
            return ftDTOs;
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
