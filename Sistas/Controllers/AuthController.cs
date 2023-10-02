using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using Sistas.Models;

namespace Sistas.Controllers
{
    public class AuthController : Controller
    {

        sistasEntities context = new sistasEntities();
        // Authentication processes are done in this controller
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel info)
        {
            // Checking to see if there is a user with these credentials.
            bool userExist = context.users.Any(x => x.username == info.username && x.userpassword == info.password);

            // The logged in user
            user u = context.users.FirstOrDefault(x => x.username == info.username && x.userpassword == info.password);


            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.username, false);
                return RedirectToAction("Index", "Home");
            }


            // Simple error message and show the same login page again
            ModelState.AddModelError("", "Username or Password is wrong");
            

            return View();
        }


        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}