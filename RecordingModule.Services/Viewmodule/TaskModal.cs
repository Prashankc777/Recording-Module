using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordingModule.Services.Viewmodule
{
    public class TaskModal
    {

        public int Id { get; set; }

        [Display(Name ="Task")]
        public string TaskName { get; set; }
        public int IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public int isEdited { get; set; }
        public DateTime EditedTime { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
