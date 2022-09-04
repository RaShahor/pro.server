using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class User
    {
        public User()
        {
            FormUsers = new HashSet<FormUser>();
            Signers = new HashSet<Signer>();
        }

        public int Id { get; set; }
        public int? PersonId { get; set; }
        public int? OfficeId { get; set; }
        [JsonIgnore]
        public virtual Office Office { get; set; }
        [JsonIgnore]
        public virtual Person Person { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormUser> FormUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Signer> Signers { get; set; }
    }
}
