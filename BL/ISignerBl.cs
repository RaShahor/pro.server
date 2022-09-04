using Entities;
using DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Pdf;

namespace BL
{
    public interface ISignerBl
    {
        List<Sign> loadSignPointsLocation(int fTSid);
        void newSignedForm(FormSignerDTO fsDto, Page page, int id);
        void addSign(Image sign, int v, int signId);
        void newSignedForm(FormSignerDTO fsDto);
        public Task<bool> sendMail(int ftsId, Office office, int signer);
    }
}
