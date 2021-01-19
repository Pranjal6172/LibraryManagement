using System;

namespace LibraryManagement.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalBookCount { get; set; }

        public int AuthorId { get; set; }

        public decimal Price { get; set; }

        public Languages Language { get; set; }

        public GenreType Genre { get; set; }

        public DateTime PublishDate { get; set; }

        public string BookImageUrl { get; set; }

        public int AvailableBookCount { get; set; }
    }
}
