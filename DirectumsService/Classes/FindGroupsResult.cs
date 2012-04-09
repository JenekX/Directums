using System.Runtime.Serialization;

namespace Directums.Service.Classes
{
    [DataContract]
    public class FindGroupsResult
    {
        [DataMember]
        public Group Group { get; set; }
        
        [DataMember]
        public int UserCount { get; set; }
    }
}
