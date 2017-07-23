using System.Web;
using System.Web.Mvc;

namespace ChurchFinanceSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // filter to require password in the whole application
            filters.Add(new AuthorizeAttribute());
            // Filter to make our application only availabe on https
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
