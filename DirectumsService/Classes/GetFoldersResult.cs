using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Directums.Service.Classes
{
    public enum GetFoldersResultType
    {
        SharedFolder,
        RootUserFolder,
        Folder,
        FolderRef
    }

    public class GetFoldersResult
    {
        public GetFoldersResult()
        {
            Type = GetFoldersResultType.Folder;
            Id = 0;
            IdParent = null;
            IdFile = null;
            Name = "";
            ReadOnly = true;
        }

        public GetFoldersResultType Type { get; set; }
        public int Id { get; set; }
        public int? IdParent { get; set; }
        public int? IdFile { get; set; }
        public string Name { get; set; }
        public bool ReadOnly { get; set; }
    }
}
