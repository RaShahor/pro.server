using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class FormSigner
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int FormTosignerId { get; set; }
        public string SavedAtFile { get; set; }
        public DateTime Date { get; set; }
        public bool? Known { get; set; }
        public string SignedFrom { get; set; }
        [JsonIgnore]
        public virtual Class Class { get; set; }
        [JsonIgnore]
        public virtual FormToSigner FormTosigner { get; set; }
    }
}
