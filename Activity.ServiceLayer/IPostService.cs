using Activity.DataLayer.Entities;
using Activity.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Activity.ServiceLayer
{
    public interface IPostService
    {
        PostAndUserVM Create(UserPostVM userPost);
        //PostsVM GetAll(DelPostUserVM user);
        void GetById(int? id, Post post);
        IEnumerable<Post> GetByUser(UserFollowersPostsVM user);
        PostsVM GetOwn(PostAndUserVM userVM);
        DeletePostVM DeletePostPrep(PostAndUserVM postAndUser);
        void DeletePost(PostAndUserVM postAndUser);
        DeletePostVM Edit(DelPostUserVM user, DeletePostVM postVM);

    }
}
