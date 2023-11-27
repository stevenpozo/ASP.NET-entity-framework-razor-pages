using MVCRazor.Models;
using MVCRazor.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRazor.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<ListPeople> lst = new List<ListPeople>();
            using (CrudMVCRazorEntities db = new CrudMVCRazorEntities())
            {
                lst = (from d in db.people
                       orderby d.id_people descending
                       select new ListPeople
                       {
                           Id = d.id_people,
                           Name = d.name,
                           Age = d.age ?? 0 // Utiliza el operador de fusión nula para proporcionar un valor predeterminado si age es nulo
                       }).ToList();
            }
            return View(lst);
        }


        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(PeopleViewModel model)
        {
            try
            {
                using (CrudMVCRazorEntities db = new CrudMVCRazorEntities())
                {
                    var oPeople = new people();
                    oPeople.name = model.Name;
                    oPeople.age = model.Age;    
                    db.people.Add(oPeople);
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch(Exception ex) 
            {
                return Content(ex.Message);

            }
        }

        public ActionResult Edit(int Id)
        {
            PeopleViewModel model = new PeopleViewModel();
            using (CrudMVCRazorEntities db =  new CrudMVCRazorEntities())
            {
                var oPeople = db.people.Find(Id);
                model.Name = oPeople.name;
                model.Age = oPeople.age;
                model.Id = oPeople.id_people;
            }
            return View(model);

        }


        [HttpPost]
        public ActionResult Update(PeopleViewModel model)
        {
            try
            {
                using (CrudMVCRazorEntities db = new CrudMVCRazorEntities())
                {
                    var oPeople = db.people.Find(model.Id);
                    oPeople.name = model.Name;
                    oPeople.age = model.Age;
                    db.Entry(oPeople).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);

            }

        }

        public ActionResult Delete(int Id)
        {
            try
            {
                using (CrudMVCRazorEntities db = new CrudMVCRazorEntities())
                {
                    var oPeople = db.people.Find(Id);
                    db.people.Remove(oPeople);
                    db.SaveChanges();
                    
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);

            }

        }
    }
}