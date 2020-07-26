using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGLOrderApp.Auth.Requirements
{
    public class ModifyItemsRequirement : IAuthorizationRequirement
    {
        public bool IsAdmin { get; }

        public ModifyItemsRequirement(bool isAdmin = false)
        {
            IsAdmin = IsAdmin;
        }
    }
}
