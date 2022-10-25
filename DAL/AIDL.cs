using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Aspose.Pdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL
{
    public class AIDL:IAIDL
    {
        private readonly SignContext myContext;
        private readonly ILogger<AIDL> logger;
        public AIDL(SignContext myC,ILogger<AIDL> logger)
        {
            myContext = myC;

            this.logger = logger;
        }
        //public Task<List<Sign>> GetAllSignsFromAIModel(Page myPdf)
        //{
        //    //myPdf.AddImage();
        //    throw new NotImplementedException();
        //}

        //public async Task<FormTemplate> getFT(string name, int id)
        //{
        //    logger.LogWarning("error 500? but logger works!!!");
        //    return myContext.FormTemplates.Where(ft => ft.Description == name).FirstOrDefault();

        //}
        ////should I return the exact ft only (by its name?)
        //public async Task<Signer> returnAwait(int id)
        //{
        //    Signer s = new Signer();
        //    return s;
        //}
    }
}
