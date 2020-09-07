using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using Prueba2.Models;
using Prueba2.Models.TableViewModel;
using Prueba2.Models.ViewModels;
namespace Prueba2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Prueba2.Models.TableViewModel.expensesAndIncomeViewModel> lst = null;
            using (alkemyChallengeEntities db = new alkemyChallengeEntities())
            {
                lst = (from d in db.userAmounts
                       orderby d.concept
                       select new expensesAndIncomeViewModel
                       {
                           concept = d.concept,
                           amount = d.amount,
                           date = d.date,
                           type = d.type

                       }).OrderByDescending(d => d).ToList();

            }

            return View(lst);
        }

    }
}
