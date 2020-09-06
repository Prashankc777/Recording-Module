using RecordingModule.DB;
using RecordingModule.Services.Interface;
using RecordingModule.Services.Viewmodule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecordingModule.Services.Services
{
    public class UserServices : IUser
    {
        RecordingModuleEntities2 db = new RecordingModuleEntities2();

        public int Adduser(UserViewModal modal)
        {

            tbluser _tbluser = new tbluser()
            {
                Id = modal.id,
                Password = modal.Password,
                UserName = modal.UserName,
                Email = modal.Email,
                Gender = modal.Gender,
                DeletedTime = null,
                EditedTime = null,
                IsDeleted = 0,
                IsEdited = 0,
                CreatedOn = DateTime.Now,            
                
                
                 
                
                
                
            };
            


            db.tbluser.Add(_tbluser);
            db.SaveChanges();


            return _tbluser.Id;
        }


        public bool IsUser(UserViewModal modal)
        {
            var result = db.tbluser.Where(x => x.UserName == modal.UserName && x.Password == modal.Password).FirstOrDefault();
            if (result != null)
            {
                return true;
            }          
                return false;      

            

        }


        public List<UserViewModal> GetALL()
        {
            var User = db.tbluser.Where(p=>p.IsDeleted ==0).Select(x => new UserViewModal()
            { Email = x.Email, Gender = x.Gender, id = x.Id, Password = x.Password, UserName = x.UserName }).ToList();

            return User;
        }

        public UserViewModal GetOne(int id)
        {
            var UserAll = db.tbluser.Where(X => X.Id == id).Select(x => new UserViewModal()
            {       
                id = x.Id,
               UserName = x.UserName,
               Gender = x.Gender,
               Email = x.Email
            
            }).FirstOrDefault();

            return UserAll;
        }

        public bool Edit(int id, UserViewModal modal)
        {
            var usr = db.tbluser.FirstOrDefault(p => p.Id == id);
            if (usr != null)
            {

                usr.UserName = modal.UserName;               
                usr.Email = modal.Email;
                usr.Gender = modal.Gender;
                usr.IsEdited = usr.IsEdited + 1;
                usr.EditedTime = DateTime.Now;

                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(int id, UserViewModal modal)
        {
            var usr = db.tbluser.FirstOrDefault(p => p.Id == id);
            if (usr != null)
            {


                usr.IsDeleted = 1;
                usr.DeletedTime = DateTime.Now;

                db.SaveChanges();
                return true;
            }

            return false;
        }


        public bool UserExist(UserViewModal modal)
        {
            var result = db.tbluser.Any(x => x.UserName == modal.UserName);
            if (result)
            {
                return false;

            }
            return true;

           


        }

        public bool EmailExist(UserViewModal modal)
        {
            var result = db.tbluser.Any(x => x.Email == modal.Email);
            if (result)
            {
                return false;

            }
            return true;




        }

       
    }
}
