using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DTO
{
    public class FormToSignerDTO 
    {
        public int id { get; set; }
        public int sID { get; set; }
        public string fullName { get; set; }
        public string descrip { get; set; }
        public string path { get; set; }
        public int order { get; set; }
        public int status { get; set; }
    }
}
