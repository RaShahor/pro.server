using System;
using System.Collections.Generic;

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

        public virtual FormTemplate FormTemplate { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<FormTemplate> FormTemplates { get; set; }
        public virtual ICollection<FormToSigner> FormToSigners { get; set; }
        public virtual ICollection<Sign> Signs { get; set; }
    }
}
