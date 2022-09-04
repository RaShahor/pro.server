using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual Office Office { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormSigner> FormSigners { get; set; }
        [JsonIgnore]
        public virtual ICollection<Sign> Signs { get; set; }
    }
}
