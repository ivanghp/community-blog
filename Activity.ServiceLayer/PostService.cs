using Activity.DataLayer.Data;
using Activity.DataLayer.Entities;
using Activity.ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Activity.ServiceLayer
{
    public class PostService : IPostService
    {
        readonly ActivityDbContext _context;
        public PostService(ActivityDbContext context)
        {
            _context = context;
        }

        public PostAndUserVM Create(UserPostVM userPost)
        {
            //user = UserService.userLogedin;
            userPost.User = UserService.userLogedin;
            try
            {
                if (userPost.User.Id == UserService.userLogedin.Id)
                {
                
                    if (userPost.Title != null || userPost.Description != null)
                    {
                        Post post = new Post
                        {
                            Title = userPost.Title,
                            Description = userPost.Description,
                            CreatedAt = DateTime.Now,
                            UserId = userPost.User.Id,
                            CreatedBy = userPost.User.Name,
                            Link = userPost.Link,
                            Location = userPost.Location,
                            Thumbnail = userPost.Thumbnail
                        };
                        _context.Posts.Add(post);
                        //user.Posts.Append(post);
                        //user.UpdatedAt = DateTime.Now; 
                        //user.UpdatedBy = "Activity App auto update"; 
                        //_context.Users.Update(user);
                        _context.SaveChanges();
                        /*if (post.UserId == user.Id)
                        {
                            user.Posts.Append(post);
                            _context.Users.Update(user);
                            _context.SaveChanges();
                        }*/
                        PostAndUserVM postVM = new PostAndUserVM
                        {
                            User = userPost.User,
                            Post = post
                        };
                        return postVM;
                    }
                }
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /*public List<DeletePostVM> GetAll(DelPostUserVM user) 
        {
            user.User = UserService.userLogedin;
            try
            {
                if (user.User != null)
                {
                    var allPosts = new List<DeletePostVM>
                    {
                        Posts = _context.Posts.ToList()
                    };
                    return allPosts;
                }
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;

            }
        }*/
        public IEnumerable<Post> GetByUser(UserFollowersPostsVM userVM)
        {
            userVM.User = UserService.userLogedin;
            try
            {
                if (userVM.User != null)
                {
                    var postsByUser= _context.Posts.Where(p => p.UserId == userVM.User.Id);//.ToList();
                    return postsByUser;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void GetById(int? id, Post post)
        {
            try
            {
                if (id == null)
                {
                    throw new NotImplementedException();
                }
                post = _context.Posts.FirstOrDefault(p => p.Id == id);
                if (post == null)
                {
                    throw new NotImplementedException();
                }
            }
            catch (Exception)
            {

                throw;

            }
        }

        public DeletePostVM DeletePostPrep(PostAndUserVM postAndUser)
        {
            postAndUser.User = UserService.userLogedin;

            //try
            //{
                
                if (postAndUser.User != null)
                {
                    var post = new DeletePostVM();
                    post.Post = _context.Posts.Single(p => p.Id == postAndUser.Post.Id);
                    return post;
                }
                throw new NotImplementedException();

            //}
            //catch (Exception)
            //{

              //  throw;
            //}
        }

        public void DeletePost(PostAndUserVM postAndUser)
        {
            postAndUser.User = UserService.userLogedin;

            try
            {
                //if (user.User == null || post.Post == null)
                //{
                  //  throw new NotImplementedException();
                //}
                if (postAndUser.User.Id == postAndUser.Post.UserId)
                {
                    var postDel = _context.Posts.SingleOrDefault(p => p.Id == postAndUser.Post.Id);
                    _context.Posts.Remove(postDel);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PostsVM GetOwn(PostAndUserVM userPost)
        {
            userPost.User = UserService.userLogedin;
            try
            {
                if (userPost.User != null)
                {
                    var ownPosts = new PostsVM();
                    ownPosts.Posts = _context.Posts.Where(p => p.UserId == userPost.User.Id).ToList();
                    return ownPosts;
                    //var vmPosts = userVM.Posts;
                    //vmPosts = ownPosts;
                    //return vmPosts;
                }
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DeletePostVM Edit(DelPostUserVM user, DeletePostVM postVM)
        {
            user.User = UserService.userLogedin;
            try
            {
                if (user.User.Id == postVM.Post.UserId)
                {
                    var post = new DeletePostVM();
                    post.Post = _context.Posts.SingleOrDefault(p => p.UserId == postVM.Post.UserId);
                    post.Post.Title = postVM.Post.Title;
                    post.Post.Description = postVM.Post.Description;
                    post.Post.Link = postVM.Post.Link;
                    post.Post.Location = postVM.Post.Location;
                    post.Post.Thumbnail = postVM.Post.Thumbnail;
                    post.Post.UpdatedAt = DateTime.Now;
                    post.Post.UpdatedBy = user.User.Name;
                    _context.SaveChanges();
                    return post;
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
