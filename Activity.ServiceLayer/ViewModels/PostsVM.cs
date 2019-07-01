using Activity.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Activity.ServiceLayer.ViewModels
{
    public class PostsVM
    {
        public ICollection<Post> Posts { get; set; }
    }
}
