using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class For_managerBL : Ifor_managerBL
    {
        private readonly IuserFor_managerDL userFor_managerDL;
        public For_managerBL(IuserFor_managerDL iuserFor_managerDL)
        {
            userFor_managerDL = iuserFor_managerDL;
        }

        public int getSignersNumberToForm(int id)
        {
            return userFor_managerDL.getSignersNumberToForm(id);
        }

        public Task<FormUser> GetUserForm(int userId, string fileName)
        {
            return userFor_managerDL.GetUserForm(userId, fileName);
        }

        public bool SaveForm(FormUser newForm)
        {
            return userFor_managerDL.SaveUserForm(newForm);
        }
    }
}
