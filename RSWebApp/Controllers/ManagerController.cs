using Entities;
using BL;
using DTO;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
//using AutoMapper;

namespace RSWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ManagerController : ControllerBase
    { 
        IManagerDL MDL;
        IManagerBL MBL;
       
        public ManagerController(IManagerDL managerDL, IManagerBL managerBL)
        {
            MDL = managerDL;
            MBL = managerBL;
           
        }
        //[HttpGet]//ניסיון
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "server is runing!", "ב,ה סוף סוף" };
        //}

        [HttpGet("{id}/FormToSigner")]
        public async Task<List<FormToSigner>> Get(int id)//פונקציה המחזירה מ-
                                                       

        {
            List<FormToSigner> trial = await MDL.getAllFormsToUserBySigner(id);
            if (trial != null)
                return trial;
            throw new NotFoundException();
    }



    [HttpGet("{id}/FormTemplate")]
    public async Task<List<FormTemplate>> GetTmp(int id)//קבלת כל תבניות הטפסים השמורות תחת משתמש מסויים
    {

        return await MDL.getAllFormsTemplatesByUser(id);
    }

    [HttpGet("{idu}/{ids}/FormTS")]
    public async Task<List<FormToSigner>> GetTmp(int idu, int ids)//קבלת כל טפסים למשתמש (רבים לרבים) של חותם נבחר של משתמש נבחר
    {

        return await MDL.getAllFormsToSignerByUserIdAndSignerId(idu, ids);
    }
    [HttpGet("{id}/Signers")]
    public async Task<List<Signer>> GetSigners(int id)//קבלת כל הלקוחות של המשתמש
    {

        return await MDL.getAllSignersByUser(id);
    }
    [HttpPost("{id}")]
    public async Task PostNewSigner( int id,[FromBody] Signer signerDTO)//שמירת לקוח חדש למשתמש - שימוש ב: מיפוי dto
    {
        await MBL.NewSigner(signerDTO,id);
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
            
            return await MBL.newFTS(formToSigner);
    }

    //PUT api/<SecretaryController>/5
        [HttpPut("{id}")]
    public async void updateStatusOfFTS(int id, [FromBody] FormToSigner fts)//עדכון סטטוס של טופס ללקוח
    {
        await MBL.updateStatusOfFTS(id, fts);
            
    }



    ////DELETE api/<SecretaryController>/5
    //    [HttpDelete("{id}/Signer")]
    //public void DeleteSigner(int id)//מחיקת לקוח תחת משתמש! מספיק רק זיהוי של לקוח? או נדרש גם זיהוי משתמש
    //{
    //    MDL.DeleteSigner(id);
    //}
    //[HttpDelete("{id}/User")]
    //public void DeleteUser(int id)//איפה למקם פונקציית הסרת לקוח אם בכלל???
    //{
    //    MBL.DeleteUser(id);
    //}


   
    //[HttpDelete("{id}/formsToSigner-range")]
    //    public void DeleteformsToSigner_range(int id, DateTime date)
    //{
    //    MBL.DeleteformsToSigner_range(id, date);
    //}
    //[HttpDelete("{id}/{tillDate}/formsToUser-range")]
    //public void DeleteformsToUser_range(int id, DateTime date)
    //{
    //    MBL.DeleteformsToUser_range(id, date);
    //}
}
}
