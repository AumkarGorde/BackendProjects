using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concepts.Controllers
{
    public class ExceptionHandlingByFilterController : Controller
    {
        // GET: ExceptionHandlingByFilter
        [HandleError]
        public ActionResult Error1()
        {
            int i = 0;
            i /= 0;
            return View();
        }
    }
}