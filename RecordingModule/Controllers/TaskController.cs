using RecordingModule.Services.Interface;
using RecordingModule.Services.Viewmodule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecordingModule.Controllers
{
    
    public class TaskController : Controller
    {

        #region ---------- GLOBAL VARIABLE ----------
        private ITask task = null; 
        #endregion

        #region ---------- CONSTRUCTOR ----------
        public TaskController(ITask _task)
        {
            task = _task;
        }

        #endregion


        #region --------- SHOWING VALUE---------
        [Route("create1")]
        public ActionResult ViewAll()
        {

            var all = task.GelALL();
            return View(all);
        }

        #endregion


        #region ---------- ADDING IN THE DATABASE ---------

        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(TaskModal modal)
        {
            if (ModelState.IsValid)
            {
                int add = task.AddTask(modal);
                return RedirectToAction("ViewAll");

            }
            ModelState.Clear();
            return View();
        }

        #endregion


        #region --------- UPDATE ---------

       

        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                var one = task.GetONE(id);
                return View(one);

            }
            ModelState.Clear();
            return View();

        }



        [HttpPost]
        public ActionResult Edit(int id, TaskModal modal)
        {
            if (ModelState.IsValid)
            {
                task.Edit(modal.Id, modal);
                return RedirectToAction("ViewAll");

            }
            return View();

        }

        #endregion


        #region --------- DETAILS ---------

        
        public ActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                var one = task.GetONE(id);
                return View(one);

            }
            ModelState.Clear();
            return View();

        }

        #endregion

        #region ---------- DELETE --------

        public ActionResult Delete(int id, TaskModal modal)
        {
            if (ModelState.IsValid)
            {
                task.Delete(modal.Id, modal);
                return RedirectToAction("ViewAll");

            }
            ModelState.Clear();
            return View();

        }

        #endregion

    }
}