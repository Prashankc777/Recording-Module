using RecordingModule.Services.Viewmodule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordingModule.Services.Interface
{
    public interface IUser
    {
        int Adduser(UserViewModal modal);
       bool IsUser(UserViewModal modal);

       
        List<UserViewModal> GetALL();

        UserViewModal GetOne(int id);

        bool Edit(int id, UserViewModal modal);
        bool Delete(int id, UserViewModal modal);

        bool UserExist(UserViewModal modal);

        bool EmailExist(UserViewModal modal);
    }

}
