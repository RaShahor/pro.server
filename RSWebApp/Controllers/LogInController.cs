using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BL;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RSWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        IlogInBL logBL;
        public LogInController(IlogInBL logBL)
        {
            this.logBL = logBL;
        }
        // GET: api/<SecretaryController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<SecretaryController>/5
        [HttpPost("{mail}/{password}")]

        public async Task<ActionResult<User>> Get(string mail, string password)
        {

            User u = await logBL.postUser(mail, password);
            if (u == null)
                return NoContent();
            else return u;
        }


        // POST: HomeController/Edit/5
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<User> Post([FromBody] User user)
        {
            return await logBL.postUser(user);
        }

        [HttpPut("{mail}")]
        public async Task Put(string mail, [FromBody] User curUser)
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
