using Directums.Classes.Core;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Directums.Service
{
    partial class DirectumsServiceDataClassesDataContext
    {
    }

    partial class User
    {
        public bool CheckOnRegister()
        {
            return RegexCheck.CheckLogin(Login) && (PasswordHash.Length == 32) && RegexCheck.CheckEmail(Email);
        }

        public bool CheckOnAdminEdit()
        {
            return RegexCheck.CheckLogin(Login) && RegexCheck.CheckEmail(Email) && (Status == 0 || Status == 1 || Status == 2);
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
