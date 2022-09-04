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
        private readonly Ifor_managerBL formService;
        // GET: api/<FormController>
        public FormController(Ifor_managerBL iform)
        {
            formService = iform;
        }
        [HttpGet("{id}/SignersToForm")]
        public int Get(int id)
        {
            return  formService.getSignersNumberToForm(id);
        }
        //    [HttpPost, DisableRequestSizeLimit]
        //    [Route("SaveForm")]
        //    public ActionResult SaveForm([FromForm] Document form,int userId)
        //    {
        //        if (form != null)
        //        {
        //            //we can send the userId from Client, or get it from Request.HttpContext.User.Identity.Name
        //            //probably we should replace the user name with user id
        //            //int userId = userId;

        //            /*if (!imageService.ValidateDuplicateFileName(userId, image.FileName))
        //                return StatusCode(500, "כבר קימת תמונה למשתמש בשם זה");*/

        //            //save file on disk
        //            //we put it in the web layer because IFormFile is part of AspNetCore.Http namespace - that is a part of the web layer
        //            //string directory = Path.Combine(@"C:\Temp", userId.ToString());
        //            var folderName = Path.Combine("Resources", userId.ToString());
        //            var directory = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //            Directory.CreateDirectory(directory);
        //            string filePath = Path.Combine(directory, form.FileName);
        //            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                form.Save(fileStream);
        //            }
        //            //Aspose.Pdf.Document
        //            //send to save in DB
        //            FormUser newForm = new FormUser
        //            {
        //                Path = Path.Combine(folderName, form.FileName), // we save only relational path
        //                FormName = form.FileName,
        //                UserId = userId
        //            };
        //            formService.SaveForm(newForm);
        //            return Ok();
        //        }return NoContent();

        //    }

        //[HttpGet]
        //[Route("GetFormForUser")]
        //public Task<FormUser> GetFormForUser(int userId,string fileName)
        //{
        //    return formService.GetUserForm(userId,fileName);
        //}
        //[HttpGet]
        //[Route("GetPDF")]
        //public Task<Page> GetPDF( string fileName)
        //{

        //    return GetPDF("wwwroot/Rsources/sample.pdf");
        //        //formService.GetUserForm(userId, fileName);
        //}
    }
}
