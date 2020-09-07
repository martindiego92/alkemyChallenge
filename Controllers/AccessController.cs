using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba2.Models;
namespace Prueba2.Controllers
{
    public class AccessController : Controller
    {
        // GET: Acces
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(string user , string pass)
        {
            try
            {
                using (alkemyChallengeEntities db = new alkemyChallengeEntities())
                {
                    var lst = from d in db.user
                              where d.email == user && d.password == pass && d.idState == 1
                              select d;
                    if(lst.Count()>0)
                    {
                        Session["User"] = lst.First();
                        return Content("1");
                    }
                    else
                    { return Content("Usuario Invalido"); }
                }

               
            }
            catch(Exception e)
            {
                return Content("Error"+e.Message);
            }
        }
    }
}