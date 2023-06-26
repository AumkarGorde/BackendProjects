using Concepts.DAL;
using Concepts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            Customer cus = new Customer
            {
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
            return View("Enter", new Customer());
        }

        public ActionResult Submit(Customer cus)
        {
            if (ModelState.IsValid)
            {
                List<Customer> cusList = new List<Customer>();
                CustomerDAL dal = new CustomerDAL();
                #region getting from http request
                //---We can use this and make Submit() without Parameter
                //Customer cus = new Customer();
                //cus.CustomerId = Convert.ToInt32(Request.Form["CustomerId"]);
                //cus.CustomerName = Request.Form["CustomerName"];
                //cus.CustomerLocation = Request.Form["CustomerLocation"];
                #endregion

                #region Save To Database
                dal.dbSet.Add(cus);
                dal.SaveChanges();
                #endregion

                cusList.Add(cus);
                return View("Customer", cusList);
            }
            else
            {

                return View("Enter", cus);
            }
        }

        //Data Annotation does not work with Model Binders
        public ActionResult SubmitModelBinder([ModelBinder(typeof(CustomerBinder))] Customer cus)
        {
            if (ModelState.IsValid)
            {
                List<Customer> cusList = new List<Customer>();
                cusList.Add(cus);
                return View("Customer", cusList);
            }
            else
            {
                return View("Enter", cus);
            }
        }

        #region
        //Ajax Implementation
        public ActionResult AjaxImplemtationEnter(Customer cus)
        {
            if (ModelState.IsValid)
            {
                CustomerDAL dal = new CustomerDAL();
                #region Save To Database
                dal.dbSet.Add(cus);
                dal.SaveChanges();
                #endregion
                return View("AjaxView", new Customer());
            }
            else
            {
                return View("AjaxView", new Customer());
            }

        }

        public ActionResult AjaxPostCall(Customer cus)
        {
            CustomerDAL dal = new CustomerDAL();
            #region Save To Database
            dal.dbSet.Add(cus);
            dal.SaveChanges();
            #endregion
            var list = dal.dbSet.ToList<Customer>();
            Thread.Sleep(10000);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCustomerFromDB()
        {
            CustomerDAL dal = new CustomerDAL();
            var list = dal.dbSet.ToList<Customer>();
            Thread.Sleep(10000);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}