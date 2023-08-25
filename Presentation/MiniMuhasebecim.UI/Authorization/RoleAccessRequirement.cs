using Microsoft.AspNetCore.Authorization;
using MiniMuhasebecim.UI.Models;

namespace MiniMuhasebecim.UI.Authorization
{
    public class RoleAccessRequirement : IAuthorizationRequirement
    {
        public Roles[] Roles { get; set; }

        public RoleAccessRequirement(params Roles[] roles)
        {
            Roles = roles;
        }
    }
}
