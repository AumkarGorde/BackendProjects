using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concepts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Variables()
        {
            ViewData["SampleTime"] = DateTime.Now; // Helps to pass data from Contoller to the View
            ViewBag.SampleData = "Data is passed from Controller to View via ViewBag"; // ViewBag is does samething as ViewData but syntax is better, but use ViewData as ViewBag uses reflection thus degrades the performance 
            return View();
        }

        public ActionResult Variables2()
        {
            TempData["TempDataEg"] = "Data is sent from SampleTwo to Sample, Action to Action via TempData";
            ViewData["TempDataEg"] = "Data is sent from SampleTwo to Sample, Action to Action via ViewData";
            Session["SessionVariable"] = $"This is Session Variable created at - {DateTime.Now}";
            TempData["KeepValueEg"] = "This is sent by TempData and we are calling TempData.Keep to persist this value in next request";
            return RedirectToAction("Variables");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}