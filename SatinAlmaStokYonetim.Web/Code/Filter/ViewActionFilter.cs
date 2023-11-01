using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SatinAlmaStokYonetim.Code.Filter
{
    public class ViewActionFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public string? ViewPageName;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!string.IsNullOrEmpty(ViewPageName))
            {
                bool isAuthorized = true;

                //bool isAuthorized = false;
                //if (ViewPageName == "TalepOnay")
                //{
                //    if (Repo.Session.TalepOnay == "True")
                //        isAuthorized = true;
                //}
                //else if (ViewPageName == "TalepOlustur")
                //{
                //    if (Repo.Session.TalepOlustur == "True")
                //        isAuthorized = true;
                //}       
                //else
                //{
                //    isAuthorized = false;
                //}

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
