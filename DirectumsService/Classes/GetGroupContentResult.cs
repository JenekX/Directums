using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Directums.Service.Classes
{
    public class GetGroupContentResult
    {
        public GetGroupContentResult()
        {
            Name = "";
            Users = new Dictionary<int, string>();
        }

        public string Name { get; set; }
        public Dictionary<int, string> Users { get; set; }
    }
}
