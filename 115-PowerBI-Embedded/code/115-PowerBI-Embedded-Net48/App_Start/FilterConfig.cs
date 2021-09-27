using System.Web;
using System.Web.Mvc;

namespace _115_PowerBI_Embedded_Net48
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
