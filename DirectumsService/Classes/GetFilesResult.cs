using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Directums.Service.Classes
{
    [DataContract]
    public class GetFilesResult
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public String Name { get; set; }
        
        [DataMember]
        public String Extension { get; set; }

        [DataMember]
        public DateTime CreatedTime { get; set; }

        public GetFilesResult(Int32 id, String name, String ex, DateTime time)
        {
            Id = id;
            Name = name;
            Extension = ex;
            CreatedTime = time;
        }
    }
}
