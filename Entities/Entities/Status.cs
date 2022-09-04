using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Status
    {
        public Status()
        {
            FormToSigners = new HashSet<FormToSigner>();
        }

        public int Id { get; set; }
        public string Status1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormToSigner> FormToSigners { get; set; }
    }
}
