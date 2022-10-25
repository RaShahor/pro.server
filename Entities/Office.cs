using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Office
    {
        public Office()
        {
            Classes = new HashSet<Class>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal? Fee { get; set; }
        public byte[] Logo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Class> Classes { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
