using Concepts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concepts.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Load()
        {
            List<Customer> cusList = new List<Customer>();
            Customer cus = new Customer{
                 CustomerId = 1,
                 CustomerName = "Omkar Gorde",
                 CustomerLocation = "India"
            };
            cusList.Add(cus);
            Customer cus1 = new Customer
            {
                CustomerId = 2,
                CustomerName = "Tony Stark",
                CustomerLocation = "USA"
            };
            cusList.Add(cus1);
            return View("Customer", cusList);
        }

        public ActionResult Enter()
        {
            return View();
        }

        public ActionResult Submit(Customer cus)
        {
            List<Customer> cusList = new List<Customer>();
            //---We can use this and make Submit() without Parameter
            //Customer cus = new Customer();
            //cus.CustomerId = Convert.ToInt32(Request.Form["CustomerId"]);
            //cus.CustomerName = Request.Form["CustomerName"];
            //cus.CustomerLocation = Request.Form["CustomerLocation"];
            cusList.Add(cus);
            return View("Customer", cusList);
        }

        public ActionResult SubmitModelBinder([ModelBinder(typeof(CustomerBinder))]Customer cus)
        {
            List<Customer> cusList = new List<Customer>();
            cusList.Add(cus);
            return View("Customer", cusList);
        }
    }
}