using BulletinBoardTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinBoardTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginSuccess()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var note = _context.Note.FirstOrDefault(t => t.NoteNo == 1);

            /*string curdate = DateTime.UtcNow.ToString("MM-dd-yyyy");
            var currentDate = DateTime.Now.Date;*/

            var list = ((from u in _context.User
                         join n in _context.Note
                         on u.UserNo equals n.UserNo
                         where n.NoteDate.Date == DateTime.Now.Date
                         && n.NoteDate.Day == DateTime.Now.Day
                         && n.NoteDate.Year == DateTime.Now.Year
                         select new UserNote
                         {
                             NoteNo = n.NoteNo,
                             NoteTitle = n.NoteTitle,
                             UserName = u.UserName,
                             NoteDate = n.NoteDate
                         })).ToList();
            this.ViewBag.curlist = list;
            return View(list);
            //return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
