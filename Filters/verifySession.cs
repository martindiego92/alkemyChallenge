using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba2.Controllers;
using Prueba2.Models;

namespace Prueba2.Filters
{
    public class verifySession : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)

        {
            var user = (user)HttpContext.Current.Session["User"];
           
            if(user == null)
            {
                if(filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                if(filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }

            }
            base.OnActionExecuting(filterContext);
        }
    }
}