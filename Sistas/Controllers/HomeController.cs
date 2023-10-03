using Sistas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace Sistas.Controllers
{
    public class HomeController : Controller
    {
        // Add the list and the alteration here
        
        // Main page render
    [Authorize]

        public ActionResult Index()
        {
            
            sistasEntities context = new sistasEntities();
            user table = context.users.FirstOrDefault(x => x.username == User.Identity.Name);
            //Test

            return View();
        }

        
    }
}