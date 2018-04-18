using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Interfaces;
using Services.Services;

namespace shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            var list = _bookService.ShowBooks();
            return View(list);
        }

       
    }
}
