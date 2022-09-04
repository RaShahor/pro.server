using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Aspose.Pdf;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class AIDL:IAIDL
    {
        private readonly SignContext myContext;
        public AIDL(SignContext myC)
        {
            myContext = myC;

            //this.logger = logger;
        }
        public Task<List<Sign>> GetAllSignsFromAIModel(Page myPdf)
        {
            //myPdf.AddImage();
            throw new NotImplementedException();
        }

        public async Task<FormTemplate> getFT(string name, int id)
        {

            return (FormTemplate)myContext.FormTemplates.Where(ft => ft.Description == name);

        }
        //should i return the exact ft only (by its name?)
        public async Task<Signer> returnAwait(int id)
        {
            Signer s = new Signer();


            return s;
        }
    }
}
