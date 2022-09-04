using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IlogInBL
    {
        Task<User> postUser(User user);
        Task putUser(string mail, User curUser);
        Task<User> postUser(string mail, string password);
    }
}