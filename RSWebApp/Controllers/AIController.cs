using BL;
using Entities;
using DTO;
using Aspose.Pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RSWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : ControllerBase
    {
        IAIBL aiBL;
        public AIController(IAIBL aIBL)
        {
            this.aiBL = aIBL;
        }
        //        // GET: api/<AI>
        //        [HttpGet]
        //        public IEnumerable<string> Get()
        //        {
        //            return new string[] { "value1", "value2" };
        //        }
        //[HttpPost]
        //public Task<List<Sign>> GetAllSignsFromAIModel([FromBody] Page pdf)
        //{
        //    return aiBL.GetAllSignsFromAIModel(pdf);
        //}

        // GET api/<AI>/5
        [HttpGet("{name}/{Uid}")]
        public async Task<FormTemplate> Get(string name, int id)
        {
            return await aiBL.getFT(name, id);

        }

        //// POST api/<AI>
        //[HttpPost("{id}")]
        //public async Task<Sign> PostAddSign([FromBody] Sign sign,int uId)
        //{
        //    return aiBL.AddSign(sign,uId);
        //}
        //[HttpPost("{id}")]
        //public async Task<Sign> PostAddFormTemplate([FromBody] FormTemplate ft, int uId)
        //{
        //    return aiBL.AddFT(ft, uId);
        //}
        //[HttpPost("{id}")]
        //public async Task<Sign> PostAddForm([FromBody] FormUserDTO formDto, int uId)
        //{
        //    return aiBL.AddForm(formDto, uId);
        //}

        //// PUT api/<AI>/5
        //[HttpPut("{id}")]
        //public void PutUpdateSign(int id, [FromBody] Sign sign, [FromBody] Sign newSign)
        //{
        //    aiBL.updateSign(sign,id,newSign);
        //}

        //// DELETE api/<AI>/5
        //[HttpDelete("{id}")]
        //public void DeleteSign(int id)
        //{
        //    aiBL.deleteSign( id);
        //}
    }
}
