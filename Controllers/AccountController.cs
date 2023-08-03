using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var uname = model.Username;
                var pw = model.Password;
                if(uname=="user" && pw == "user")
                {
                    return RedirectToAction("Index","Product");
                }
            }
            return View();
        }
    }
}