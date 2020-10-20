using System;

namespace Dotnext.ApplicationServices.Interfaces
{
    [Flags]
	public enum AccessLevel
    {
		PartialView = 1,
		View = 2,
		Edit = 8,
		Administration = 16
    }
}
