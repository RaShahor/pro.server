using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AutoMapper;
using DAL;
using DTO;
using Entities;
using Microsoft.Extensions.Logging;

namespace BL
{
    public class ManagerBL : IManagerBL

    {
        IManagerDL managerDL;
        //IMapper map;
        ILogger<ManagerBL> logger;
        public ManagerBL(IManagerDL managerDL,ILogger<ManagerBL>log)
            //public ManagerBL(IManagerDL managerDL, IMapper mapper, ILogger<ManagerBL> log)
        {
            this.managerDL = managerDL;
           // map = mapper;
            logger = log;
        }



        public Task<Signer> NewSigner(Signer signerDTO, int UId)
        {
            return managerDL.newSigner(signerDTO, UId);
        }
        public async Task<FormToSigner> newFTS(FormToSigner form)
        {
            //FormToSigner fts = new FormToSigner() { SignerId = sId, FormId = form.Id, Class = cls, Status = status, Order = (byte?)order };
            return await managerDL.newFTS(form);
        }

        public async Task updateStatusOfFTS(int status, FormToSigner fts)
        {
            fts.Status = status;//update status
            managerDL.updateStatusOfFTS(status, fts);
            logger.LogInformation("we updated bsd status of" + fts.SId + " to be " + status);
        }

        public async Task DeleteSigner(int id)
        {
            await managerDL.DeleteSigner(id);
        }

        public async Task DeleteformsToSigner_range(int id, DateTime date)
        {
            managerDL.DeleteformsToSigner_rangeAsync(id, date);
        }

        public async Task DeleteUser(int id)
        {
            managerDL.DeleteUser(id);
        }

        public async Task DeleteformsToUser_range(int id, DateTime date)
        {
            managerDL.DeleteformsToUser_range(id, date);
        }
    }
}


