using Activity.DataLayer.Data;
using Activity.DataLayer.Entities;
using Activity.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Activity.ServiceLayer
{
    public class UserService : IUserService
    {
        readonly ActivityDbContext _context;
        public UserService(ActivityDbContext context)
        {
            _context = context;
        }

        public static User userLogedin;
        public void Register(UserVM user)
        {
            if (!(_context.Users.Any(x => x.Name == user.Name)))
            {
                User dbUser = new User
                {
                    Name = user.Name,
                    Password = user.Password,
                    CreatedAt = DateTime.Now,
                    CreatedBy = user.Name
                };
                _context.Users.Add(dbUser);
                _context.SaveChanges();
            }
        }

        public PostAndUserVM LogIn(PostAndUserVM user)
        {
            userLogedin = _context.Users.FirstOrDefault(x => x.Name == user.User.Name && x.Password == user.User.Password);
           

            if (userLogedin != null)
            {
                return user;
            }
            throw new NotImplementedException();
        }

        public DelPostUserVM LogOut(DelPostUserVM user)
        {
            user.User = userLogedin;
            try
            {
                if (userLogedin != null)
                {
                    userLogedin = null;
                    return null;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        //
        public List<string> GetMany(string userName)
        {
            try
            {
                if (!String.IsNullOrEmpty(userName))
                {
                    var searched = _context.Users.Where(u => u.Name.Contains(userName)).ToList(); //.Select(x => x.Name)
                    return searched;
                }
                return null;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public DelPostUserVM Edit(DelPostUserVM userVM)
        {
            userVM.User = userLogedin;
            try
            {
                if (userVM.User != null)
                {
                    var user = new DelPostUserVM();
                    user.User = _context.Users.SingleOrDefault(p => p.Id == userVM.User.Id);
                    user.User.Name = userVM.User.Name;
                    user.User.Password = userVM.User.Password;
                    user.User.UpdatedAt = DateTime.Now;
                    user.User.UpdatedBy = userVM.User.Name;
                    //_context.Update(user.User);
                    _context.SaveChanges();
                    return user;
                }
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
