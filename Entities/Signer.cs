using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
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
        public DateTime? PassTime { get; set; }

        public virtual Person Person { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormToSigner> FormToSigners { get; set; }
    }
}
