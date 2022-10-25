using Aspose;
using Aspose.Pdf;
using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RSWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        //funcs of this controller:
        //1.get num of signers per form
        //2.get all fts for office
        //3.get all ft per office
        //4.new fts
        //5.get fts per signer (and office of course)
        //6.update status of fts
        
        
        private readonly IformBL _formService;
        // GET: api/<FormController>
        public FormController(IformBL iform)
        {
            _formService = iform;
        }


        [HttpGet("{id}/SignersToForm")]
        public int Get(int id)
        {
            return  _formService.getSignersNumberToForm(id);
        }


        [HttpGet("{id}/FormToSigner")]
        public async Task<List<FormToSigner>> GetAllFormsToSignersByOffice(int id)//get all forms relates to signers by office
        {
            List<FormToSigner> trial = await _formService.getAllFormsToUserBySigner(id);
            if (trial != null)
                return trial;
            throw new NotFoundException();
        }

        
        [HttpGet("{id}/FormTemplate")]
        public async Task<List<FormTemplate>> GetTmp(int id)//קבלת כל תבניות הטפסים השמורות תחת משתמש מסויים
        {

            return await _formService.getAllFormsTemplatesByUser(id);
        }

        
        [HttpGet("{idu}/{ids}/FormTS")]
        public async Task<List<FormToSigner>> GetFTSPerSigner(int idu, int ids)//קבלת כל טפסים למשתמש (רבים לרבים) של חותם נבחר של משתמש נבחר
        {

            return await _formService.getAllFormsToSignerByUserIdAndSignerId(idu, ids);
        }

        [HttpPost("{Sid}/{cls}/{status}/{order}")]//שמירת טופס חדש ללקוח
        public async Task<FormToSigner> PostNewFormToSigner([FromBody] FormUser form, int SId, int cls, int status, int order)
        {
            FormToSigner formToSigner = new FormToSigner();
            formToSigner.Class = (short)cls;
            formToSigner.FormId = form.Id;
            formToSigner.SignerId = SId;
            formToSigner.Status = status;
            formToSigner.Order = (byte?)order;

            return await _formService.newFTS(formToSigner);
        }


        [HttpPut("{id}")]
        public async void updateStatusOfFTS(int id, [FromBody] FormToSigner fts)//עדכון סטטוס של טופס ללקוח
        {
            await _formService.updateStatusOfFTS(id, fts);

        }

        [HttpGet("{name}/{Uid}")]
        public async Task<FormTemplate> GetSingleFT(string name, int id)
        {
            return await _formService.getFT(name, id);

        }
    }
}
