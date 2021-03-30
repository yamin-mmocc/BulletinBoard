using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BulletinBoardTest.Models;
using BulletinBoardTest.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetNote.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _context;

        public AccountController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                    var user = _context.User.FirstOrDefault(t => t.UserId == model.UserId
                                && t.UserPassword == model.UserPassword);
                    if (user != null)
                    {
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);
                        return RedirectToAction("LoginSuccess", "Home");
                    }

                ModelState.AddModelError(string.Empty, "User ID or Password is not correct");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();  //Clear all session
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
        }

        // GET: /<controller>/
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                //using (var db = _context)
                //{
                //    db.User.Add(model);  //upload data to memory
                //    db.SaveChanges();  //save data to sql table
                //}
                _context.User.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

    }
}