using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Person
    {
        public Person()
        {
            Signers = new HashSet<Signer>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public decimal IdentityNumber { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        [JsonIgnore]
        public virtual ICollection<Signer> Signers { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
