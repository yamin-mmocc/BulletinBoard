using BulletinBoardTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinBoardTest.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationContext _context;

        public NoteController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            //using (var db = _context)
            //{
            //    var list = db.Note.ToList();
            //    return View(list);
            //}
            //var list = _context.Note.ToList();

            var list = ((from u in _context.User
                         join n in _context.Note
                         on u.UserNo equals n.UserNo                        
                         select new UserNote
                         {
                             NoteNo = n.NoteNo,
                             NoteTitle = n.NoteTitle,
                             UserName = u.UserName,
                             NoteDate = n.NoteDate
                         })).ToList();
            return View(list);
        }


        public IActionResult Detail(int noteNo)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            //using (var db = _context)
            //{
            //    var note = db.Note.FirstOrDefault(n => n.NoteNo.Equals(noteNo));
            //    return View(note);
            //}

            var note = _context.Note.FirstOrDefault(t => t.NoteNo == noteNo);
            return View(note);
        }

        public IActionResult Add()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public IActionResult AddNote()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Add(Note model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());

            if (ModelState.IsValid)
            {
                //using (var db = _context)
                //{
                //    db.Note.Add(model);

                //    var result = db.SaveChanges();   //Commit
                //    if (result > 0)
                //    {
                //        return Redirect("Index");
                //    }
                //}
                _context.Note.Add(model);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return Redirect("Index");
                }
                ModelState.AddModelError(string.Empty, "Cannot add the content");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult AddNote(Note model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());

            if (ModelState.IsValid)
            {
                //using (var db = _context)
                //{
                //    db.Note.Add(model);

                //    var result = db.SaveChanges();   //Commit
                //    if (result > 0)
                //    {
                //        return Redirect("Index");
                //    }
                //}
                _context.Note.Add(model);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return Redirect("Index");
                }
                ModelState.AddModelError(string.Empty, "Cannot add the content");
            }
            return View(model);
        }

        public IActionResult Edit()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();

        }

        public IActionResult Delete()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
