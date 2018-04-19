using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseLevel.Entities;
using Microsoft.AspNet.Identity;
using shop.Models;
using Services.Interfaces;

namespace shop.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        protected Book dbBook;

        public BookController(IBookService BookService, IUserService userService)
        {
            _bookService = BookService;
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(AddBookModel model)
        {
            dbBook = new Book()
            {
                Name = model.Name,
                Author = model.Author,
                Cost = model.Cost,
                PageCount = model.PageCount,
                Description = model.Description,
                Genre = model.Genre,
                Type = model.Type,
                UserId = _userService.IdTransfer(HttpContext.ApplicationInstance.User.Identity.GetUserId()),
                Id = Guid.NewGuid()
            };
            _bookService.AddBook(dbBook);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ViewCurrentBook(Guid id)
        {
            return View(_bookService.FindById(id));
        }

        [HttpGet]
        public JsonResult ViewUserInfo(Guid id)
        {
            var user = _userService.FindById(id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult BuyBook(Guid Id)
        {
            var Book = _bookService.FindById(Id);
            Guid buyerId = _userService.IdTransfer(HttpContext.ApplicationInstance.User.Identity.GetUserId());
            if (Book.UserId != buyerId)
            {
                Book.BuyerId = buyerId;
                _bookService.UpdateBook(Book);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult BooksOfCurrentuser()
        {
            var list = _bookService.GetUserBooks(_userService.IdTransfer(HttpContext.ApplicationInstance.User.Identity.GetUserId()));
            return View(list);
        }

        public ActionResult UpdateBook(Guid id)
        {
            var Book = _bookService.FindById(id);
            return View(Book);
        }

        [HttpPost]
        public ActionResult ChangeBook(Book Book)
        {
            _bookService.UpdateBook(Book);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public JsonResult SortBooks(string value)
        {
            return Json(_bookService.GetSortedBooks(value), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult FilterBooks(string value)
        {
            return Json(_bookService.GetFilteredBooks(value), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteBook(Guid id)
        {
            _bookService.DeleteBook(_bookService.FindById(id));
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewBuyBooks()
        {
            var Books = _bookService.GetBuyerBooks(_userService.IdTransfer(HttpContext.ApplicationInstance.User.Identity.GetUserId()));
            return View(Books);
        }

        public ActionResult DeletePurchase(Guid id)
        {
            var Book = _bookService.FindById(id);
            Book.BuyerId = null;
            _bookService.UpdateBook(Book);
            return RedirectToAction("Index", "Home");
        }
    }
}
