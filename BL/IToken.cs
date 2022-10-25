using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL
{
    public interface IToken
    {

        public string BuildToken(string key, string issuer,UserDTO user);
        public bool IsTokenValid(string key, string issuer, string audience, string token);
    }
}
