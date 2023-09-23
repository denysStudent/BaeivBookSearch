using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookSearch.Models;

namespace BookSearch.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Book()
        {
            return View();
        }
        
        [HttpPost]
        public  ActionResult  Book(string title, string author)
        {
            if (title == null)
            {
                title = "White Fang";
            }
            if (author == null)
            {
                author = "Jack London";
            }
            TempData["title"] = title;
            TempData["author"] = author;
            return View();
        }

        public  JsonResult SearchBook()
        {
            BookModel book = new BookModel();

            if (TempData["title"] == null)
            {
                TempData["title"] = "White Fang";
            }
            if (TempData["author"] == null)
            {
                TempData["author"] = "Jack London";
            }
            string title = TempData["title"].ToString();
            string author = TempData["author"].ToString();
            return Json(book.getBookList(title, author), JsonRequestBehavior.AllowGet);
        }

    }


}