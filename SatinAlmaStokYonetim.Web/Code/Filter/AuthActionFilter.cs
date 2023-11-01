using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SatinAlmaStokYonetim.Code.Filter
{
    public class AuthActionFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public string? Rol;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!string.IsNullOrEmpty(Rol))
            {
                bool isAuthorized = Rol.Split(',').Contains(Repo.Session.Authority);
                if (!isAuthorized)
                    context.Result = new UnauthorizedResult();
            }
            else if (string.IsNullOrEmpty(Repo.Session.Username))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
