using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Infrastructure
{
    using Microsoft.AspNetCore.Authorization;

    public class BlockUsersRequirement : IAuthorizationRequirement
    {
        internal readonly string[] BlockedUsers;

        public BlockUsersRequirement(params string[] blockedUsers)
        {
            this.BlockedUsers = blockedUsers;
        }
    }
}
