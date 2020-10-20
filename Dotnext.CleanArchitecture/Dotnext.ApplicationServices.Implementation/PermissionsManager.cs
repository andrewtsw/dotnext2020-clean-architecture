using Dotnext.ApplicationServices.Interfaces;
using Dotnext.DataAccess.Interfaces;
using System;

namespace Dotnext.ApplicationServices.Implementation
{
    internal class PermissionsManager : IPermissionsManager
    {
        private readonly IDbContext _context;

        public PermissionsManager(IDbContext context)
        {
            _context = context;
        }

        public ObjectAccessLevel[] GetCurrentUserPermissions()
        {
            // TODO: load permissions from DB/Cache
            return new ObjectAccessLevel[0];
        }

        public ObjectAccessLevel[] GetUserPermissions(string userId, ObjectType type)
        {
            // TODO: load permissions from DB/Cache
            return new ObjectAccessLevel[0];
        }
    }
}
