using RecordingModule.Services.Interface;
using RecordingModule.Services.Viewmodule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecordingModule.Controllers
{
    // [Authorize]
    public class UserController : Controller
    {
        IUser user = null;


        public UserController(IUser _user)
        {
            user = _user;
        }
      
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModal modal)
        {
         
                bool ans = user.IsUser(modal);
                if (ans)
                {

                    return RedirectToAction("ViewAll", "DashBoard");
                }


                else
                {
                    ViewBag.error = "Username or password Incorrect"; 
                }



            ModelState.Clear();
            return View();
        }



       

       


    }
}