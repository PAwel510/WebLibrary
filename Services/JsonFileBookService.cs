using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Services
{
    public class JsonFileBookService
    {

        public JsonFileBookService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
            
        }

        public IWebHostEnvironment WebHostEnvironment { get; }


        private string JsonFileName { get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "new.json"); } }

        public IEnumerable<Book> GetBooks()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Book[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        public void SaveBooks(IEnumerable<Book> books)
        {
            string booksToJson = JsonSerializer.Serialize(books);
            File.WriteAllText(JsonFileName, booksToJson);
           
        }

        public void AddRating(int bookISBN, int rating)
        {
            var books = GetBooks();

            var query = books.First(x => x.ISBN == bookISBN);
            if (query.Ratings == null)
            {
                query.Ratings = new int[] { rating };
            }
            else
            {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Book>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    books
                );
            }
        }


    }
   
}


