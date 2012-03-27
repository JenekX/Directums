using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Directums.Service.Classes
{
    [DataContract]
    public class FindUsersResult
    {
        [DataMember]
        public User[] Users { get; set; }
        
        [DataMember]
        public int PageCount { get; set; }
    }
}
