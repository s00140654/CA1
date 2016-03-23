using System.Web;
using System.Web.Mvc;

namespace Ca1_RAD_302
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
