using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Entities;

namespace BL
{
    public interface IToken
    {

        public string BuildToken( string issuer,User user);
        public bool IsTokenValid(string key, string issuer, string audience, string token);
    }
}
