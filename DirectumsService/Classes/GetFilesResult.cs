using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Directums.Service.Classes
{
    public enum GetFilesResultType
    {
        Folder,
        FolderRef,
        File,
        FileRef
    }

    public class GetFilesResult
    {
        public int Id { get; set; }
        public int IdFile { get; set; }
        public GetFilesResultType Type { get; set; }
        public int IdOwner { get; set; }
        public string OwnerName { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public bool ReadOnly { get; set; }
        public DateTime Created { get; set; }
    }

    public class GetFilesResultTypeComparer : IComparer<GetFilesResultType>
    {
        public int Compare(GetFilesResultType x, GetFilesResultType y)
        {
            if ((x == GetFilesResultType.Folder || x == GetFilesResultType.FolderRef) && (y == GetFilesResultType.File || y == GetFilesResultType.FileRef))
            {
                return -1;
            }
            else if ((x == GetFilesResultType.File || x == GetFilesResultType.FileRef) && (y == GetFilesResultType.Folder || y == GetFilesResultType.FolderRef))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}