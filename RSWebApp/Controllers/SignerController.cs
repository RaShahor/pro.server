using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Pdf;

using Entities;
using BL;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RSWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SignerController : ControllerBase
    {
        private ISignerBl _signerBL;
        public SignerController(ISignerBl sbl)
        {
            _signerBL = sbl;
        }
        // GET: api/<SignerController>
        [HttpGet("{mail}")]
        public Task<bool> GetPWD(string mail)
        {
            return _signerBL.getPassword(mail);
        }

        //// GET api/<SignerController>/5
        //[HttpGet("{id}")]
        //public Page loadPDF(int FTSid)
        //{
        //    return "value";
        //}
        //GET api/<SignerController>/5
        //[HttpGet("{id}")]
        //public async Task<List<Sign>> loadSignLocationPoints(int FTSid)
        //{
        //    return _signerBL.loadSignPointsLocation(FTSid); 
        //}

        // POST api/<SignerController>
        [HttpPost]
        public async Task<string> Post(int fts,int signer,[FromBody] Office office)
        {
            bool res;
            try
            {
                res=await _signerBL.sendMail(fts, office, signer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "an error occourd when tried to send email";
            }if(!res)
                return "an error occourd when tried to send email";
            return "mail was sent succesfully!";
        }
        
        //// POST api/<SignerController>
        //[HttpPost]
        //public void newSignedForm([FromBody] FormSignerDTO fsDto)
        //{
        //    _signerBL.newSignedForm(fsDto);
        //}
        //[HttpPost]
        //public void newSignImage([FromBody] Image sign,int fts,int signId)
        //{
        //    _signerBL.addSign(sign,-fts,signId);
        //}

        //[HttpPost]
        //public void buildSignedForm([FromBody] FormSignerDTO fsDto,Page page,FormToSigner fts)//int ftsId
        //{
        //    _signerBL.newSignedForm(fsDto,page,fts.Id);
        //}

        //// PUT api/<SignerController>/5
        //[HttpPut("{id}")]
        //public void updateSign(int id, [FromBody] string value)
        //{
            
        //}

        //// DELETE api/<SignerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        // DELETE api/<SignerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
