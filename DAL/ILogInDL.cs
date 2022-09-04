using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface ILogInDL
    {
        Task<List<User>> GetAllUsers();//למנהל - כל המשתמשים
        Task<User> PostUser(string email, string pwd);//כניסה - לקוח קיים
        Task<User> PostUser(User user);//משתמש חדש
        Task<User> PutUser(string email, User user);//עדכון מייל
    }
}