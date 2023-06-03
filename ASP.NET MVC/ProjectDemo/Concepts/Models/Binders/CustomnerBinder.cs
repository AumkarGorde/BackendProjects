using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concepts.Models
{
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var objContext = controllerContext.HttpContext;
            Customer customer = new Customer();
            customer.CustomerId = Convert.ToInt32(objContext.Request.Form["txtId"]);
            customer.CustomerName = objContext.Request.Form["txtName"];
            customer.CustomerLocation = objContext.Request.Form["txtLocation"];
            return customer;
        }
    }
}