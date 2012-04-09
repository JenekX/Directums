using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Directums.Service.Classes
{
    public class GetFilePropertiesResult
    {
        public byte Type { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public User Owner { get; set; }
        public DateTime Created { get; set; }
    }
}
