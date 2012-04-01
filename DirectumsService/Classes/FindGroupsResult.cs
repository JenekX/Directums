using System.Runtime.Serialization;

namespace Directums.Service.Classes
{
    [DataContract]
    public class FindGroupsResult
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public bool Status { get; set; }

        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public int UserCount { get; set; }
    }
}
