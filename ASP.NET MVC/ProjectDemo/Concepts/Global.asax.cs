using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Concepts
{
    // Refer on how you can Implement DI - https://www.c-sharpcorner.com/article/dependency-injection-in-asp-net-mvc-5/ 
    public class MvcApplication : System.Web.HttpApplication
    {
       
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            // to have a global error handling 
            //GlobalFilters.Filters.Add(new HandleErrorAttribute()); --> in this no need to add filter attribute on controllers implemented for all

            //We can also add number of custom filters or error attribute
            //HandleErrorAttribute a = new HandleErrorAttribute();
            //a.ExceptionType = typeof(DivideByZeroException);
            //a.View = "Error";
            //GlobalFilters.Filters.Add(a);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
    /// <summary>
    /// This is custom filter error attribute, in case if we want to log exception globally on one class
    /// </summary>
    public class CustomFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error";
            filterContext.Result = viewResult;
            filterContext.ExceptionHandled = true;

            Exception e = filterContext.Exception;
            // here you can log exception
        }
    }
}
