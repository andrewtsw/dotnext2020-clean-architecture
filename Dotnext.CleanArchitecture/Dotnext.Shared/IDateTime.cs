using System;

namespace Dotnext.Shared
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}
