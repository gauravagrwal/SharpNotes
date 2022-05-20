using Realms;
using System;

namespace SharpNotes.Models
{
    public class Note : RealmObject
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public MetaData MetaData { get; set; }
    }

    public class MetaData : EmbeddedObject
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
    }
}
