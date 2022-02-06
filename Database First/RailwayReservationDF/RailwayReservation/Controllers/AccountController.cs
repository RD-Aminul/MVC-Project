using RailwayReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RailwayReservation.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult PostLogin(tblUser obj)
        {
            using (var dbObj = new RailwayDBEntities())
            {
                var count = dbObj.tblUsers.Where(u => u.UserName == obj.UserName && u.Password == obj.Password).Count();
                if (count <= 0)
                {
                    ViewBag.Msg = "Invalid User";
                    return View();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(obj.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ActionName("SignUp")]
        public ActionResult PostSignUp(tblUser obj)
        {
            using (var dbObj = new RailwayDBEntities())
            {
                bool isExists = !dbObj.tblUsers.Any(u => u.UserName == obj.UserName);
                if (isExists)
                {
                    dbObj.tblUsers.Add(obj);
                    dbObj.SaveChanges();
                    int count = dbObj.tblUsers.Count();
                    //if (count==1)
                    //{
                    //    return RedirectToAction("CreateRole", "SuperAdmin");
                    //}
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "User Already Exists");
                    return View();
                }
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}