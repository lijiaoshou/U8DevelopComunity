using System.Web;
using System.Web.Mvc;
using U8DevelopComunity.Filters;

namespace U8DevelopComunity
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomExceptionFilter());
        }
    }
}
