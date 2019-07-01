using Activity.DataLayer.Entities;
using Activity.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Activity.ServiceLayer
{
    public interface IUserService //where T : class
    {
        void Register(UserVM user);
        PostAndUserVM LogIn(PostAndUserVM user);
        DelPostUserVM LogOut(DelPostUserVM user);
        //
        List<string> GetMany(string userName);
        DelPostUserVM Edit(DelPostUserVM userVM);
    }
}
