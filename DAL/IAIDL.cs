using Aspose.Pdf;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAIDL//interface
    {
        public Task<List<Sign>> GetAllSignsFromAIModel(Page myPdf);
        Task<Signer> returnAwait(int id);
        Task<FormTemplate> getFT(string name, int id);
    }
}