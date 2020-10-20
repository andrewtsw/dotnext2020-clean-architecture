using System;

namespace Dotnext.ApplicationServices.Interfaces
{
    [Flags]
    public enum ObjectType
    {
        Product = 1,
        Order = 2,
        // ...
    }
}
