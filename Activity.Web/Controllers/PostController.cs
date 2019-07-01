using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Activity.DataLayer.Entities;
using Activity.ServiceLayer;
using Activity.ServiceLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Activity.Web.Controllers
{
    public class PostController : Controller
    {
        readonly IPostService _service;
        public PostController(IPostService service)
        {
            _service = service;
        }

        /*public IActionResult Index(DelPostUserVM userVM)//dava nul referens, kako ne go prepoznava modelot u vju-to..
        {
            var model =_service.GetAll(userVM);
            return View(model);
        }*/

        public IActionResult Create()
        {
            return View("CreatePost");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title, Description, Thumbnail, Location, Link")] UserPostVM userPost)
        {
            if (ModelState.IsValid)
            {
                var model =_service.Create(userPost);
                return View("PostCreated",model);
            }
            return View("CreatePost");
            throw new NotImplementedException();
        }

        public IActionResult Details(int? id, Post post)
        {
            _service.GetById(id, post);
            return View(post);
        }

        public IActionResult GetByUser(UserFollowersPostsVM userVM) //i tuka isto..
        {
            var model = _service.GetByUser(userVM);
            return View(model);
        }

        public IActionResult MyProfile(PostAndUserVM userVM)
        {
            var model = _service.GetOwn(userVM);
            return View("MyProfile", model);
        }

        public IActionResult Delete(PostAndUserVM postVM) //null
        {
            var model = _service.DeletePostPrep(postVM);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFinal(PostAndUserVM postAndUser)
        {
            _service.DeletePost(postAndUser);
            return View("MyProfile");
        }

        public IActionResult EditPost(DelPostUserVM userVM, DeletePostVM postVM) //
        {
            return View(postVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost1(DelPostUserVM userVM, DeletePostVM postVM)
        {
            _service.Edit(userVM, postVM);
            return View("EditPost");
        }
    }
}