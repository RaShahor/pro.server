using System;
using System.Collections.Generic;

#nullable disable

namespace RSWebApp.Entities
{
    public partial class Signer
    {
        public Signer()
        {
            FormToSigners = new HashSet<FormToSigner>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<FormToSigner> FormToSigners { get; set; }
    }
}
