using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface Ifor_managerBL
    {
        public bool SaveForm(FormUser newForm);
        public Task<FormUser> GetUserForm(int userId, string fileName);
        int getSignersNumberToForm(int id);
    }
}