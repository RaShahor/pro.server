using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IuserFor_managerDL
    {

        Task<FormUser> GetUserForm(int userId, string fileName);
        bool SaveUserForm(FormUser newForm);
        int getSignersNumberToForm(int id);
    }
}