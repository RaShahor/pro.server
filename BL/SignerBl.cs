using Aspose.Pdf;
using DAL;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SignerBl : ISignerBl

    {
        ISignerDl _signerDl;
        public List<SignImage> signsToBuild { get; set; }//Image
         
        public SignerBl(ISignerDl sdl)
        {
            _signerDl = sdl;
            signsToBuild = new List<SignImage>();//Image
        }
        public void addSign(Image sign, int v, int signId)
        {
            signsToBuild.Add(new SignImage(v, sign, signId));
        }

        public List<Sign> loadSignPointsLocation(int fTSid)
        {
            throw new NotImplementedException();
        }

        //public void newSignedForm(FormSignerDTO fsDto)
        //{
        //    throw new NotImplementedException();
        //}

        public void newSignedForm(FormSignerDTO fsDto, Page page, int id)
        {
            //foreach (SignImage si in signsToBuild)
            //{
            //    //if (si.id == -fsDto.id) { 
            //    //    Stamp s=new 
            //    //    page.AddStamp(stmp);
            //    // }
            //}
        }

        public void newSignedForm(FormSignerDTO fsDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> sendMail(int ftsId, Office office, int signer)
        {
            return this._signerDl.sendMail(ftsId,office,signer);
        }

        /// <summary>
        /// //////////
        /// </summary>
        public class SignImage
        {
            public int id { get; set; }
            public Image image { get; set; }
            public int sid { get; set; }
            public SignImage(int id, Image image, int sid)
            {
                this.id = id;
                this.image = image;
                this.sid = sid;
            }
        }
    }
}
