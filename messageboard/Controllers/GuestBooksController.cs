using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using messageboard.Models.EFModels;

namespace messageboard.Controllers
{
    public class GuestBooksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: GuestBooks
        public ActionResult Index()
        {
            return View(db.GuestBooks.ToList());
        }

        // GET: GuestBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuestBooks/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Cellphone,Message")] GuestBook guestBook)
        {
            if (ModelState.IsValid)
            {
                guestBook.Createtime = DateTime.Now; //加這行在Controller
                db.GuestBooks.Add(guestBook);
                db.SaveChanges();
                return RedirectToAction("Confirm");
            }
            return View(guestBook);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Confirm()
        {
            return View();
        }
    }
}
