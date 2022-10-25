using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class FormTemplate
    {
        public FormTemplate()
        {
            FormUsers = new HashSet<FormUser>();
        }

        public int Id { get; set; }
        public int FormUserId { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual FormUser FormUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormUser> FormUsers { get; set; }
    }
}
