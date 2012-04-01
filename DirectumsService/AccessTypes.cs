using System;

namespace Directums.Service
{
    public enum AccessType
    {
        Guest,
        Authorized,
        Admin
    }

    [Flags]
    public enum AccessStatus
    {
        None = 0,
        Inactive = 1,
        Active = 2,
        Blocked = 4,
        All = 7
    }
}