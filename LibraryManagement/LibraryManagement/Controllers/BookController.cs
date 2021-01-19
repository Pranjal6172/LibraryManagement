using System;
using System.Collections.Generic;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private static readonly List<Book> Books = new List<Book>() {
                new Book(){ Id = 1, Name="Harry Potter", AuthorId = 1, TotalBookCount = 7, Language = Languages.English, 
                    Genre = GenreType.Fantasy, AvailableBookCount = 6, Price = 200, PublishDate = DateTime.UtcNow },
                new Book(){ Id = 2, Name="Ramayan", AuthorId = 2, TotalBookCount = 20, Language = Languages.Hindi,
                    Genre = GenreType.Historic, AvailableBookCount = 3, Price = 130, PublishDate = DateTime.UtcNow },
                new Book(){ Id = 3, Name="Game Changer", AuthorId = 3, TotalBookCount = 10, Language = Languages.English,
                    Genre = GenreType.Drama, AvailableBookCount = 9, Price = 112, PublishDate = DateTime.UtcNow },
                new Book(){ Id = 4, Name="My Journey", AuthorId = 4, TotalBookCount = 100, Language = Languages.English,
                    Genre = GenreType.Scientific, AvailableBookCount = 0, Price = 500, PublishDate = DateTime.UtcNow },
        };

        public IEnumerable<Book> GetBooks()
        {
            return Books;
        }

        [Route("{bookId:int}")]
        public Book GetBook(int bookId)
        {
            return Books.Find(bo => bo.Id == bookId);
        }

        [Route("add")]
        public IEnumerable<Book> PostBook([FromBody] Book book)
        {
            Books.Add(book);
            // needs to return id newly added row
            return Books;
        }

        [Route("update/{bookId:int}")]
        public IEnumerable<Book> PutBook(int bookId, [FromBody] Book book)
        {
            var bookIndex = Books.FindIndex(bo => bo.Id == bookId);
            if (bookIndex >= 0)
            {
                Books[bookIndex] = book;
            }

            return Books;
        }
    }
}
