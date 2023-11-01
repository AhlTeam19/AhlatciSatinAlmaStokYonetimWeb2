namespace SatinAlmaStokYonetim.Code
{
    public class Repo
    {
        public class Session
        {
            public static string? UserId
            {
                get
                {
                    string KullaniciId = (new HttpContextAccessor()).HttpContext.Session.GetString("UserId");
                    return KullaniciId;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("UserId", value ?? "");
                }
            }
            public static string? Username
            {
                get
                {
                    string Username = (new HttpContextAccessor()).HttpContext.Session.GetString("Usemrname");
                    return Username;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Usemrname", value ?? "");
                }
            }
            public static string? Token
            {
                get
                {
                    string token = (new HttpContextAccessor()).HttpContext.Session.GetString("Token");
                    return token;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Token", value ?? "");
                }
            }
            public static string? Company
            {
                get
                {
                    string sirket = (new HttpContextAccessor()).HttpContext.Session.GetString("Company");
                    return sirket;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Company", value ?? "");
                }
            }
            public static string? CompanyName
            {
                get
                {
                    string sirket = (new HttpContextAccessor()).HttpContext.Session.GetString("CompanyName");
                    return sirket;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("CompanyName", value ?? "");
                }
            }
            public static string? CompanyId
            {
                get
                {
                    string sirketId = (new HttpContextAccessor()).HttpContext.Session.GetString("CompanyId");
                    return sirketId;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("CompanyId", value ?? "");
                }
            }
            public static string? Authority
            {
                get
                {
                    string rol = (new HttpContextAccessor()).HttpContext.Session.GetString("Authority");
                    return rol;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Authority", value ?? "");
                }
            }
            public static string? Department
            {
                get
                {
                    string sirket = (new HttpContextAccessor()).HttpContext.Session.GetString("Department");
                    return sirket;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Department", value ?? "");
                }
            }
            public static string? DepartmentName
            {
                get
                {
                    string sirket = (new HttpContextAccessor()).HttpContext.Session.GetString("DepartmentName");
                    return sirket;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("DepartmentName", value ?? "");
                }
            }
            public static string? DepartmentId
            {
                get
                {
                    string sirketId = (new HttpContextAccessor()).HttpContext.Session.GetString("DepartmentId");
                    return sirketId;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("DepartmentId", value ?? "");
                }
            }
        }

    }
}
