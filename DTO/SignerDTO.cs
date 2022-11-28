using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SignerDTO:Signer
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
    }
}
