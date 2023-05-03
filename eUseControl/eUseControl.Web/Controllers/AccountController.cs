using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Acount
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}