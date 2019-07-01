using Activity.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Activity.ServiceLayer.ViewModels
{
    public class UserFollowersPostsVM
    {
        public User User { get; set; }

        public ICollection<User> Followers { get; set; }

        public ICollection<User> Following { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
