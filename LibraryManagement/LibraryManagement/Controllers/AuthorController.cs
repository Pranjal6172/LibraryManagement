using System.Collections.Generic;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private static readonly List<Author> Authors = new List<Author>() {
                new Author(){ Id = 1, Name = "J.K Rowling", Description = "Everything is fantasy"},
                new Author(){ Id = 2, Name = "Valmiki", Description = "I am from ancient time."},
                new Author(){ Id = 3, Name = "Shahid Afridi", Description = "I am from pakistan, nothing more than this."},
                new Author(){ Id = 4, Name = "Dr. APJ Abdul Kalam", Description = "Above All."}
        };
        
        public IEnumerable<Author> GetAuthors()
        {
            return Authors;
        }

        [Route("{authorId:int}")]
        public Author GetAuthor(int authorId)
        {
            return Authors.Find(au => au.Id == authorId);
        }

        [Route("add")]
        public IEnumerable<Author> PostAuthor([FromBody] Author author)
        {
            Authors.Add(author);
            // needs to return id newly added row
            return Authors;
        }

        [Route("update/{authorId:int}")]
        public IEnumerable<Author> PutAuthor(int authorId, [FromBody] Author author)
        {
            var authorIndex = Authors.FindIndex(bo => bo.Id == authorId);
            if (authorIndex >= 0)
            {
                Authors[authorIndex] = author;
            }

            return Authors;
        }

        [Route("delete/{authorId:int}")]
        public IEnumerable<Author> DeleteAuthor(int authorId)
        {
            var authorIndex = Authors.FindIndex(bo => bo.Id == authorId);
            if (authorIndex >= 0)
            {
                Authors.RemoveAt(authorIndex);
            }

            return Authors;
        }
    }
}
