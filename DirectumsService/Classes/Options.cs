using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Directums.Service.Classes
{
    public class Options
    {
        public int IdAllUsersGroup { get; set; }
        public int IdSharedFolder { get; set; }
        public int MaxFileSize { get; set; }
    }
}