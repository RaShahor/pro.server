using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class FormToSigner
    {
        public FormToSigner()
        {
            FormSigners = new HashSet<FormSigner>();
        }

        public FormToSigner(int sId, int id, int cls, int status, int order)
        {
            SId = sId;
            Id = id;
            Cls = cls;
            Status = status;
            Order1 = order;
        }

        public int Id { get; set; }
        public int SignerId { get; set; }
        public int? FormId { get; set; }
        public short Class { get; set; }
        public int? Status { get; set; }
        public byte? Order { get; set; }
        [JsonIgnore]
        public virtual FormUser Form { get; set; }
        [JsonIgnore]
        public virtual Signer Signer { get; set; }
        [JsonIgnore]
        public virtual Status StatusNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormSigner> FormSigners { get; set; }
        public int SId { get; }
        public int Cls { get; }
        public int Order1 { get; }
    }
}
