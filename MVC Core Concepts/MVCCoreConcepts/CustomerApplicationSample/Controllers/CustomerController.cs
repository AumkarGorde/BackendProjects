using CustomerApplicationSample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplicationSample.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Details(Customer customer)
        {
            return View(customer);
        }
    }
}
