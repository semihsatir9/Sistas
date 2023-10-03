using Sistas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace Sistas.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // Add the list and the alteration here
        sistasEntities context = new sistasEntities();
        // Main page render

        [HttpGet]
        public ActionResult Index()
        {

            
            user table = context.users.FirstOrDefault(x => x.username == User.Identity.Name);
            //Test

            return View();
        }

        [HttpPost]
        public ActionResult Index(userdata usertable)
        {
            context.userdatas.Add(usertable);
            context.SaveChanges();

            return RedirectToAction("Display");
        }

        [HttpGet]
        public ActionResult Display()
        {

            var obj = context.userdatas.ToList();
            return View(obj);
            

            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var obj = context.userdatas.Find(id);
            var obj2 = context.userdatas.Find(id).id;
            return View(obj);



        }

        [HttpPost]
        public ActionResult Edit(userdata usertable)
        {
            using (sistasEntities entities = new sistasEntities())
            {
                userdata userdata = (from c in entities.userdatas
                                            where c.id == usertable.id
                                            select c).FirstOrDefault();

                if (userdata != null)
                {
                    userdata.data1 = usertable.data1;
                    userdata.data2 = usertable.data2;
                    userdata.data3 = usertable.data3;
                    userdata.data4 = usertable.data4;
                    entities.SaveChanges();
                    return Json(true);
                }
            }

            return Json(false);

           
        }

        

    

        [HttpGet]
        public ActionResult Delete(int id)
        {
            
            var obj = context.userdatas.Find(id);
            return View(obj);



        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            userdata user = context.userdatas.Find(id);

            context.userdatas.Remove(user);

            context.SaveChanges();

            return RedirectToAction("Display");



        }
    }
}