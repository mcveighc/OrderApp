using BGLOrderApp.Auth.Requirements;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGLOrderApp.Auth.Handlers
{
    public class ModifyItemsHandler : AuthorizationHandler<ModifyItemsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ModifyItemsRequirement requirement)
        {
            // Check for the admin claim here before allowing modification of items
            if (!context.User.HasClaim(c => c.Type == "isAdmin")) 
                return Task.CompletedTask;

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
