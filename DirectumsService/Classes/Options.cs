using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Directums.Service.Classes
{
    [DataContract]
    public class Options
    {
        [DataMember]
        public int IdAllUsersGroup { get; set; }
        [DataMember]
        public int MaxFileSize { get; set; }
    }
}