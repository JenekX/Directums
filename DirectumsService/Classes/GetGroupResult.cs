using System.Runtime.Serialization;

namespace Directums.Service.Classes
{
    [DataContract]
    public class GetGroupResult
    {
        [DataMember]
        public Group Group { get; set; }

        [DataMember]
        public User[] Users { get; set; }
    }
}
