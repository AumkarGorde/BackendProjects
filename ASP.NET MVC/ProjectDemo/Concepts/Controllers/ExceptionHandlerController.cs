using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Concepts.Controllers
{
    public class ExceptionHandlerController : Controller
    {
        /// <summary>
        /// To use this logic in all the controller follow the steps:- 
        /// 1. Create a base controller inherit from Controller
        /// 2. Then this base controller will be impleted to all the controllers
        /// 3. All the override logic will be written in base controller.
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error";
            filterContext.Result = viewResult;
            filterContext.ExceptionHandled = true;
        }
        // basic approach
        public ActionResult Error1()
        {
            try
            {
                int i = 0;
                i /= 0;
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }

        }

        #region example of resusing exception handling logic
        public ActionResult Error2()
        {
            int i = 0;
                i /= 0;
            return View();
        }
        public ActionResult Error3()
        {
            int i = 0;
            i /= 0;
            return View();
        }
        #endregion
    }

    #region CORS attribute example
    public class AllowCrossSite: System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            if (filterContext.Response != null)
                filterContext.Response.Headers.Add("Access-Control-Allow-Cross-Origin","");// check
            base.OnActionExecuted(filterContext);
        }
    }
    #endregion

}