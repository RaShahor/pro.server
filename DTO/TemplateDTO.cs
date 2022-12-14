using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TemplateDTO

    {
        public int Id { get; set; }
        public int FormUserId { get; set; }
        public string description { get; set; }
        public int numOfSigners { get; set; }
        public int numOfSigns { get; set; }
        public string owner { get; set; }
        public ICollection<Entities.Sign> signs { get; set; }
    }
}
