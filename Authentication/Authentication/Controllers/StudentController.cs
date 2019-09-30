using Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Authentication.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        public static List<Student> studentList = new List<Student>(){

            new Student(){Name = "Mr. A" , Roll = "1" , Section = "A" },
            new Student(){Name = "Mr. B" , Roll = "2" , Section = "B" },
            new Student(){Name = "Mr,. C" , Roll = "3" , Section = "C" },

            };

        public object FormsAuthencation { get; private set; }

        [Authorize]
        public ActionResult Index()
        {
            return View(studentList);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

                return RedirectToAction("Index");
        }

    }
}