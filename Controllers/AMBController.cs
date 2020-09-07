using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba2.Models;
using Prueba2.Models.TableViewModel;
using Prueba2.Models.ViewModels;
namespace Prueba2.Controllers
{
    public class AMBController : Controller
    {
        // GET: AMB
        public ActionResult Index()
        {
            List<Prueba2.Models.TableViewModel.expensesAndIncomeViewModel> lst = null;
            using(alkemyChallengeEntities db= new alkemyChallengeEntities())
            {
                lst =( from d in db.userAmounts
                      orderby d.concept
                      select new expensesAndIncomeViewModel
                      {
                          concept = d.concept,
                          amount = d.amount,
                          date = d.date,
                          type = d.type

                      }).ToList();
                      
            }

            return View(lst);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Add(AMBViewModels model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using(var db= new alkemyChallengeEntities())
            {
                userAmounts users = new userAmounts();
                users.concept = 1;
                users.amount = model.amount;
                users.date = model.date;
                users.type = model.type;

                db.userAmounts.Add(users);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/AMB/"));
        }
        public ActionResult Edit(int Id)
        {
            EditAMBViewModels model = new EditAMBViewModels();

            using(var db = new alkemyChallengeEntities())
            {
                var user = db.userAmounts.Find(Id);
              
                model.amount =(float) user.amount;
                model.date =(DateTime) user.date;
                model.type = user.type;
                model.concept = user.concept;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditAMBViewModels model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new alkemyChallengeEntities())
            {
                var user = db.userAmounts.Find(model.concept);
                user.amount = model.amount;
                user.date = model.date;
                user.type = model.type;
               
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            
            return Redirect(Url.Content("~/AMB/"));
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {

            using (var db = new alkemyChallengeEntities())
            {
                var user = db.userAmounts.Find(Id);

                user.isIDstate = 3;

                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

    }
        
}