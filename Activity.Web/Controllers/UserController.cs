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
    public class UserController : Controller
    {
        readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(int id = 0)
        {
            UserVM user = new UserVM();
            return View(user);
        }

        [HttpPost]
        public ActionResult Register([Bind("Name,Password")] UserVM user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Register(user);
                    return RedirectToAction("Index", "Home");
                }
                return View("Register");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult LogIn1(PostAndUserVM userVM)
        {
            try
            {
                var model = _service.LogIn(userVM);
                return View("BasePage", model/*UserService.userLogedin.User*/);
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        public IActionResult LogOut(DelPostUserVM user)
        {
            _service.LogOut(user);
            return View("~/Views/Home/Index.cshtml");
        }
        //
        public IActionResult SearchUser(string userName) //ok e u service, mislam, ama ne gi dava u vju kako so treba..
        {
            _service.GetMany(userName);
            //ViewData["UserSearch"] = userName;
            return View();
        }
    }
}