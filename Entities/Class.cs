using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Class
    {
        public Class()
        {
            FormSigners = new HashSet<FormSigner>();
            Signs = new HashSet<Sign>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OfficeId { get; set; }

        public virtual Office Office { get; set; }
        public virtual ICollection<FormSigner> FormSigners { get; set; }
        public virtual ICollection<Sign> Signs { get; set; }
    }
}
