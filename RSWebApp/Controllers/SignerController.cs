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

        [HttpGet("{id}/Signers")]
        public async Task<List<Signer>> GetSigners(int id)//קבלת כל הלקוחות של המשתמש
        {

            return await _signerBL.getAllSignersByUser(id);
        }


        [HttpPost("{id}")]
        public async Task PostNewSigner(int id, [FromBody] Signer signerDTO)//שמירת לקוח חדש למשתמש - שימוש ב: מיפוי dto
        {
            await _signerBL.NewSigner(signerDTO, id);
        }
        // DELETE api/<SignerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
