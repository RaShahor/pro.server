using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserFor_managerDL : IuserFor_managerDL
    {
        private readonly SignContext ctx;
        public UserFor_managerDL(SignContext ctx)
        {
            this.ctx = ctx;
        }

        public int getSignersNumberToForm(int id)
        {
            return ctx.FormUsers.Find(id).NumOfSigners;
        }

        public async Task<FormUser> GetUserForm(int userId, string fileName)
        {
            return await ctx.FormUsers.Where(f => f.UserId == userId && f.FormName == fileName).FirstAsync();
        }

        public bool SaveUserForm(FormUser newForm)
        {
            ctx.FormUsers.Add(newForm);
            int i = ctx.SaveChanges();
            if (i < 1)
                return false;
            return true;
        }


    }
}
