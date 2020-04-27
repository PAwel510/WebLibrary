using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Services
{
    public class BookService
    {
        private readonly JsonFileBookService jsonBookService;
        private List<Book> books;
        public List<Book> AllBooks { get { return books; } }

        public BookService(JsonFileBookService jsonFileBookService)
        {
            this.jsonBookService = jsonFileBookService;
            books = jsonBookService.GetBooks().ToList();
        }

  

        public void Add(Book book)
        {
            AllBooks.Add(book);
            jsonBookService.SaveBooks(AllBooks);
        }
        public void Delete(int ISBN) 
        {
            books.RemoveAll(x => x.ISBN == ISBN);
            jsonBookService.SaveBooks(books);
        }

    }
}
