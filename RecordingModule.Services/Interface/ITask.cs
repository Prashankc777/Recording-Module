using RecordingModule.Services.Viewmodule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordingModule.Services.Interface
{
   public  interface ITask

        
    {
        List<TaskModal> GelALL();

        int AddTask(TaskModal modal);

        TaskModal GetONE(int ID);

        bool Edit(int id, TaskModal modal);

        bool Delete(int id, TaskModal modal);

        
    }
}
