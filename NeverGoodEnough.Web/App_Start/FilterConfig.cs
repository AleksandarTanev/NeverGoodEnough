using System.Web;
using System.Web.Mvc;

namespace NeverGoodEnough.Web
{
    using System;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType = typeof(Exception),
                View = "CustomError"
            });
            filters.Add(new OutputCacheAttribute()
            {
                Duration =  2
            });
        }
    }
}
