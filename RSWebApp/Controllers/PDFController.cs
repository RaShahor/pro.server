using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
//using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
//using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RSWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // public class eBookResult : System.Web.Http.IHttpActionResult
    //{
    //    MemoryStream bookStuff;
    //    string PdfFileName;
    //    HttpRequestMessage httpRequestMessage;
    //    HttpResponseMessage httpResponseMessage;
    //    public eBookResult(MemoryStream data, HttpRequestMessage request, string filename)
    //    {
    //        bookStuff = data;
    //        httpRequestMessage = request;
    //        PdfFileName = filename;
    //    }
    //    public System.Threading.Tasks.Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
    //    {
    //        httpResponseMessage = httpRequestMessage.CreateResponse(HttpStatusCode.OK);
    //        httpResponseMessage.Content = new StreamContent(bookStuff);
    //        //httpResponseMessage.Content = new ByteArrayContent(bookStuff.ToArray());  
    //        httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
    //        httpResponseMessage.Content.Headers.ContentDisposition.FileName = PdfFileName;
    //        httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

    //        return System.Threading.Tasks.Task.FromResult(httpResponseMessage);
    //    }
    //}
    
        public class PDFController : ControllerBase
        {

            string bookPath_Pdf = @"C:\MyWorkSpace\SelfDev\UserAPI\UserAPI\Books\sample.pdf";
            string bookPath_xls = @"C:\MyWorkSpace\SelfDev\UserAPI\UserAPI\Books\sample.xls";
            string bookPath_doc = @"C:\MyWorkSpace\SelfDev\UserAPI\UserAPI\Books\sample.doc";
            string bookPath_zip = @"C:\MyWorkSpace\SelfDev\UserAPI\UserAPI\Books\sample.zip";

            //[System.Web.Http.HttpGet()]
            //[Route("Ebook/GetFormPDFFor/{name}")]
            //public System.Web.Http.IHttpActionResult GetbookFor(string format)
            //{
            //    string reqBook = format.ToLower() == "pdf" ? bookPath_Pdf : (format.ToLower() == "xls" ? bookPath_xls : (format.ToLower() == "doc" ? bookPath_doc : bookPath_zip));
            //    string bookName = "sample." + format.ToLower();

            //    //converting Pdf file into bytes array  
            //    var dataBytes = System.IO.File.ReadAllBytes(reqBook);
            //    //adding bytes to memory stream   
            //    var dataStream = new MemoryStream(dataBytes);
            //    return new eBookResult(dataStream, RequestMessage, bookName);
            //}
            //[HttpGet]
            //[Route("Ebook/GetBookForHRM/{format}")]
            //public HttpResponseMessage GetBookForHRM(string format)
            //{
            //    string reqBook = format.ToLower() == "pdf" ? bookPath_Pdf : (format.ToLower() == "xls" ? bookPath_xls : (format.ToLower() == "doc" ? bookPath_doc : bookPath_zip));
            //    string bookName = "sample." + format.ToLower();
            //    //converting Pdf file into bytes array  
            //    var dataBytes = File.ReadAllBytes(reqBook);
            //    //adding bytes to memory stream   
            //    var dataStream = new MemoryStream(dataBytes);

            //    HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            //    httpResponseMessage.Content = new StreamContent(dataStream);
            //    httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            //    httpResponseMessage.Content.Headers.ContentDisposition.FileName = bookName;
            //    httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            //    return httpResponseMessage;
            //}
        }


        //// GET: api/<PDFController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<PDFController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PDFController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PDFController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PDFController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

//}
