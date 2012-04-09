namespace Directums.Service.Classes
{
    public class GetAccessRightsResult
    {
        public bool IsUser { get; set; }
        public int IdItem { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
    }
}