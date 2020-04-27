using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebLibrary.Models
{
    public class Book
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string BookBorrower { get; set; }

        public int ISBN { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastRental { get; set; }
        [NotMapped]
        public int[] Ratings { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Book>(this);

    }
}
