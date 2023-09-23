/*
   DESIGNER: Denys Baiev (ID: 100661798)
   Date: 20/09/2023   
   Project Name: Book Search 
*/

//importing libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookSearch.Models;

namespace BookSearch.Controllers
{
    // Main controller, used to navigate through the pages
    public class BookController : Controller
    {
        // GET: Book/Index
        // Controller responsible for the main page
        public ActionResult Index()
        {
            return View();
        }

        // GET: Book/Book
        // Controller responsible for the book search page
        public ActionResult Book()
        {
            return View();
        }

        // POST: Book/Book
        // Controller responsible for the book search page with POST request method
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

        // Method, which is used to send API call to the Google Book API
        public  JsonResult SearchBook()
        {
            BookModel book = new BookModel();

            if (TempData["title"] == null)
            {
                TempData["title"] = "Fang";
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