using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface ILogInDL
    {
        Task<List<User>> GetAllUsers();//למנהל - כל המשתמשים
        Task<User> PostExistingUser(string email, string pwd);//כניסה - לקוח קיים
        Task<User> PostNewUser(User user);//משתמש חדש
        Task<User> PutUser(string email, User user);//עדכון מייל
    }
}