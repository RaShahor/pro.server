using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class FormUser
    {
        public FormUser()
        {
            FormTemplates = new HashSet<FormTemplate>();
            FormToSigners = new HashSet<FormToSigner>();
            Signs = new HashSet<Sign>();
        }

        public int Id { get; set; }
        public string FormName { get; set; }
        public int? FormTemplateId { get; set; }
        public int UserId { get; set; }
        public string Path { get; set; }
        public bool? Resign { get; set; }
        public short NumOfSigners { get; set; }
        [JsonIgnore]
        public virtual FormTemplate FormTemplate { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormTemplate> FormTemplates { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormToSigner> FormToSigners { get; set; }
        [JsonIgnore]
        public virtual ICollection<Sign> Signs { get; set; }
    }
}
