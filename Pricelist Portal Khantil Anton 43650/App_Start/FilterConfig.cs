using System.Web;
using System.Web.Mvc;

namespace Pricelist_Portal_Khantil_Anton_43650
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
