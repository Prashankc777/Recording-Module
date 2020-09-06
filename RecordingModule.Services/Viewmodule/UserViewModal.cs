using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordingModule.Services.Viewmodule
{
    public class UserViewModal
    {
        public int id { get; set; }

        [Required(ErrorMessage ="User Name is Required")]
        [ Display(Name ="User Name")]      
       

        public string UserName { get; set; }

        
        public string Password { get; set; }
        [Compare("Password" , ErrorMessage = "Password doesnot Match !!")]
        public string ConfimPassword { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }
        public int? IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public int? IsEdited { get; set; }
        public  DateTime? EditedTime { get; set; }
        public  DateTime? CreatedOn { get; set; }
        public int? Taskid { get; set; }

        public TaskModal task { get; set; }




    }
}
