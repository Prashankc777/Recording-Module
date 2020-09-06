using RecordingModule.DB;
using RecordingModule.Services.Interface;
using RecordingModule.Services.Viewmodule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecordingModule.Services.Services
{


    public class TaskServices : ITask
    {

        #region ---------- GLOBAL VARIABLE ----------
        RecordingModuleEntities2 db = new RecordingModuleEntities2();
        # endregion 


        #region ---------- Adding to Dabatase ----------
        public int AddTask(TaskModal modal)
        {

            tblTask _tblTask = new tblTask()
            {
                ID = modal.Id,
                TaskName = modal.TaskName,
                IsEdited = 0,
                IsDeleted = 0,
                EditedTime = null,
                DeletedTime = null,
                CreatedOn = DateTime.Now ,
                
               
                

            };

            db.tblTask.Add(_tblTask);
            db.SaveChanges();

            return _tblTask.ID;
        }
        #endregion


        #region ---------- SHOWING VALUE ----------       

        public List<TaskModal> GelALL()
        {
            var taskAll = db.tblTask.Where(z=>z.IsDeleted == 0).Select(x => new TaskModal()
            { Id = x.ID, TaskName = x.TaskName }).ToList();

            return taskAll;
        }

        #endregion

        #region ---------- EDIT ----------
        
        public TaskModal GetONE(int ID )
        {
            var taskAll = db.tblTask.Where(X => X.ID == ID).Select(x => new TaskModal()
            { Id = x.ID, TaskName = x.TaskName }).FirstOrDefault();

            return taskAll;
        }

        public bool Edit(int id, TaskModal modal)
        {
            var tsk = db.tblTask.FirstOrDefault(p => p.ID == id);
            if (tsk !=null)
            {
                
                tsk.TaskName = modal.TaskName;
                tsk.IsEdited = tsk.IsEdited +1 ;
                tsk.EditedTime = DateTime.Now;

                db.SaveChanges();
                return true;
            }

               return false;
        }

        #endregion


        #region ---------- DELETE ----------
        public bool Delete(int id, TaskModal modal)
        {
            var tsk = db.tblTask.FirstOrDefault(p => p.ID == id);
            if (tsk != null)
            {

                tsk.IsDeleted = 1;
                tsk.DeletedTime = DateTime.Now;

                db.SaveChanges();
                return true;
            }

            return false;
        }
        #endregion

       
    }
}
