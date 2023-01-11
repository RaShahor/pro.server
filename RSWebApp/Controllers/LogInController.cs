using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BL;
using Entities;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RSWebApp.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    [Authorize]
    public class LogInController : ControllerBase
    {
        readonly IlogInBL logBL;
        //readonly IToken tokenService;
        readonly BL.IToken myToken;
        public LogInController(IlogInBL logBL,BL.IToken tok)
        {
            this.logBL = logBL;
            myToken = tok;
            //tokenService = token;, IToken token
        }
        // GET: api/<SecretaryController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<SecretaryController>/5
        [HttpPost("{mail}/{password}")]
        public async Task<ActionResult<User>> logIn(string mail, string password)
        {

            User u = await logBL.postUser(mail, password);
            if (u == null)
                return NoContent();
            else return u;
        }

        //[HttpPost("{mail}/{password}")]

        //public async Task<ActionResult<User>> logIn(string mail, string password)
        //{
        //    tokenService.BuildToken(mail, password);

        //}

        // POST: HomeController/Edit/5
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<User> newUser([FromBody] User user)
        {
            return await logBL.postUser(user);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<string> getToken()
        {
            User u = await logBL.postUser("str@ing", "string");
            return myToken.BuildToken("me",u);
        }
        [HttpPut("{mail}")]
        public async Task updateMail(string mail, [FromBody] User curUser)
        {

            logBL.putUser(mail, curUser);

        }


        //// DELETE api/<SecretaryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
