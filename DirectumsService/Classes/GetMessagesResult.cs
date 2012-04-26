using System;

namespace Directums.Service.Classes
{
    public class GetMessagesResult
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public int NotReadCount { get; set; }
        public DateTime Created { get; set; }
    }
}