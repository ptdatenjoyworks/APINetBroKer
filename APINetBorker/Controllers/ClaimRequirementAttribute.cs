using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Core.Constants;
using System.Linq;

namespace APINetBorker.Controllers
{
    public class PermissionRequirementAttribute : TypeFilterAttribute
    {
        public PermissionRequirementAttribute(params string[] claimValue) : base(typeof(PermissionRequirementFilter))
        {
            Arguments = new object[] { claimValue };
        }
    }

    public class PermissionRequirementFilter : IAuthorizationFilter
    {
        string[] Permission;

        public PermissionRequirementFilter(string[] permission)
        {
            Permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == CustomClaim.Permission && Permission.Any(x=>x == c.Value));
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
