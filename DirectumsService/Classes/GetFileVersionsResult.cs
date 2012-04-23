using System;

namespace Directums.Service.Classes
{
    public class GetFileVersionsResult
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public string OwnerName { get; set; }
        public DateTime Created { get; set; }
        public bool IsHidden { get; set; }
    }
}