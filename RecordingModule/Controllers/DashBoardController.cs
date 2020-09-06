using RecordingModule.Services.Interface;
using RecordingModule.Services.Viewmodule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecordingModule.Controllers
{
   [Authorize]
    public class DashBoardController : Controller
    {
        IUser user = null;
        ITask task = null;
        bool isAnyUser;
        bool EmailExist;



        public DashBoardController(IUser _user, ITask _task)
        {
            user = _user;
            task = _task;
        }

        [Route("select")]
        public ActionResult ViewAll()
        {
            var All = user.GetALL();
            return View(All);
        }

        [HttpGet]
        public ActionResult Signup()
        {
            var gender = new List<string>() { "Male", "Female", "Other" };
            ViewBag.gender = gender;
            var list = task.GelALL();
            if (list.Any())
            {
                ViewBag.task = list;

            }
            return View();
        }

        [HttpPost]
        public ActionResult Signup(UserViewModal modal)
        {

            if (ModelState.IsValid)
            {
                 isAnyUser = user.UserExist(modal);
                 EmailExist = user.EmailExist(modal);
                if (isAnyUser)
                {

                    if (EmailExist)
                    {
                        int id = user.Adduser(modal);
                        if (id > 0)
                        {

                            return RedirectToAction("ViewAll");
                        }

                    }

                    else
                    {
                        ViewBag.error = "Email Already Exist"; 

                    }
                }
                else
                {
                    ViewBag.error = "User Already Exist";
                }

            }
            var list = task.GelALL();
            ViewBag.task = list;
            ModelState.Clear();
            return View();

        }




        public ActionResult Edit(int id)
        {
            var gender = new List<string> { "Male", "Female", "Other" };
            ViewBag.gender = gender;
            if (ModelState.IsValid)
            {
                var one = user.GetOne(id);
                return View(one);

            }
            ModelState.Clear();
            return View();

        }

        [HttpPost]
        public ActionResult Edit(int id, UserViewModal modal)
        {
            if (ModelState.IsValid)
            {
                isAnyUser = user.UserExist(modal);
                EmailExist = user.EmailExist(modal);
                if (isAnyUser)
                {

                    if (EmailExist)
                    {
                        user.Edit(modal.id, modal);
                        return RedirectToAction("ViewAll");
                    }
                    else
                    {
                        ViewBag.error = "Email Already Exist";

                    }
                }

                else
                {
                    ViewBag.error = "User Already Exist";
                }

            }
            return View();

        }
     

        public ActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                var one = user.GetOne(id);
                return View(one);

            }
            ModelState.Clear();
            return View();

        }

 

        
        public ActionResult Delete(int id, UserViewModal modal)
        {        
            
            user.Delete(modal.id, modal);
            return RedirectToAction("ViewAll");            
          

        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "User");
        }



        public ActionResult database()
        {
            return View();
        }


    

    }
}
