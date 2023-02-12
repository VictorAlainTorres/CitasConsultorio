using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitasConsultorio.Controllers;
using CitasConsultorio.Models;

namespace CitasConsultorio.Filters
{
    public class VerifySession: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usuario = (Usuario)HttpContext.Current.Session["usuario"];

            if (usuario == null && filterContext.Controller is LoginController == false)
            {
                filterContext.HttpContext.Response.Redirect("~/Login");
            } else if (usuario != null && filterContext.Controller is LoginController)
            {
                filterContext.HttpContext.Response.Redirect("~/Home");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}