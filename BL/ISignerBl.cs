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
        void addSign(Image sign, int v, int signId);
        public Task<bool> sendMail(int ftsId, Office office, int signer);
        public Task<bool>getPassword (string mail);
        List<SignerDTO>getAllSignersByUser(int id);
        Task<Signer> NewSigner(SignerDTO signerDTO, int UId);
    }
}
