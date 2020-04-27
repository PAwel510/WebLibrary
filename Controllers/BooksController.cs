using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;
using WebLibrary.Services;

namespace WebLibrary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksController(JsonFileBookService bookService, BookService service)
        {
            this.jsonBookService = bookService;
            this._bookService = service;
        }

        public JsonFileBookService jsonBookService { get; }
        public BookService _bookService;


        public IEnumerable<Book> Get()
        {
            return jsonBookService.GetBooks();
        }


        //[HttpPatch] "[FromBody]"
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery]int bookISBN,
            [FromQuery]int Rating)
        {
            jsonBookService.AddRating(bookISBN, Rating);
            return Ok();
        }

        [HttpGet]
        public ActionResult Delete(
            int bookId)
        {
            _bookService.Delete(bookId);
            return Redirect("/");
        }

        [HttpPost]
        public IActionResult AddNew([FromForm]Book book)
        {
            _bookService.Add(book);
            return Redirect("/");
        }


    }
}
