using Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Authentication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            User user = new User();

            return View(user);
        }

        [HttpPost]
        public ActionResult Index(User user, string ReturnUrl)
        {
            if (IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);

                return Redirect(ReturnUrl);
            }
            else
            {
                return View();
            }
           
        }

        private bool IsValid(User user)
        {

            return user.Name == "test" && user.Password == "test";
        }
    }
}