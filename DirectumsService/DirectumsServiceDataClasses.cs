using Directums.Classes.Core;
using System.ServiceModel;

namespace Directums.Service
{
    partial class DirectumsServiceDataClassesDataContext
    {
    }

    partial class User
    {
        [OperationContract]
        public bool CheckOnRegister()
        {
            return RegexCheck.CheckLogin(Login) && (PasswordHash.Length == 32) && RegexCheck.CheckEmail(Email);
        }
    }

    partial class Item
    {
        public const byte FileOrFolder = 0;
        public const byte SharedFolder = 1;
        public const byte UserFolder = 2;
        public const byte ObjectRef = 3;
    }
}
