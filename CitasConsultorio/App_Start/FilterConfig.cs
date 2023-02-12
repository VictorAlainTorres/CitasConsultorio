using System.Web;
using System.Web.Mvc;
using CitasConsultorio.Filters;

namespace CitasConsultorio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerifySession());
        }
    }
}
