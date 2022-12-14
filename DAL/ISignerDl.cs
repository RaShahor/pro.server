using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISignerDl
    {
        //public Task<bool> sendMail(int ftsId, Office office, int signer);
        Task<Signer> getSignerById(int signer);
        Task<Person> getPersonById(int personId);
        string getPassword(string mail);
        DateTime getPassTime(string mail);
        Task<List<Signer>> getAllSignersByUser(int id);
        Task<Signer> newSigner(Signer signer, int Uid = 1);
    }
}
