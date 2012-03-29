using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Directums.Service.Classes
{
    [DataContract]
    public class GetDirsResult
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public Int32 IdParent { get; set; }

        [DataMember]
        public Int32 IdItem { get; set; }

        [DataMember]
        public Int32 typeAccess { get; set; }
        
        public GetDirsResult(Int32 id, String name, Int32 parent, Int32 item = -1, Int32 type = -1)
        {
            Id = id;
            Name = name;
            IdParent = parent;
            IdItem = item;
            typeAccess = type;
        }
     }
}
