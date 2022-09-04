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
        public Task<bool> sendMail(int ftsId, Office office, int signer);
    }
}
