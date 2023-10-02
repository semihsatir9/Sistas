using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            bool userExist = context.users.Any();
            return View();
        }


        public ActionResult Signout()
        {
            return View();
        }

    }
}