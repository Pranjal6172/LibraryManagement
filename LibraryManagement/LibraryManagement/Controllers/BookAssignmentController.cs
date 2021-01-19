using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAssignmentController : ControllerBase
    {
        private static readonly List<BookAssignment> BookAssignments = new List<BookAssignment>() {
                new BookAssignment(){ Id = 1, BookId = 1, AssignedUserId = 123456789,
                    AssignmentDate =  DateTime.UtcNow, AssignmentStatus = AssignmentStatus.Issued },
                new BookAssignment(){ Id = 2, BookId = 2, AssignedUserId = 12852789,
                    AssignmentDate =  DateTime.UtcNow, AssignmentStatus = AssignmentStatus.Issued },
                new BookAssignment(){ Id = 3, BookId = 1, AssignedUserId = 98756789,
                    AssignmentDate =  DateTime.UtcNow, AssignmentStatus = AssignmentStatus.Issued },
                new BookAssignment(){ Id = 4, BookId = 3, AssignedUserId = 852147963,
                    AssignmentDate =  DateTime.UtcNow, AssignmentStatus = AssignmentStatus.Returned },
        };

        public IEnumerable<BookAssignment> GetAllBookAssignment()
        {
            return BookAssignments;
        }

        [Route("book/{bookId:int}", Name ="GetAssignmentByBookId")]
        public IEnumerable<BookAssignment> GetBookAssignment(int bookId)
        {
            return BookAssignments.Where(ba => ba.BookId == bookId);
        }

        [Route("user/{userId:int}", Name = "GetAssignmentByUserId")]
        public IEnumerable<BookAssignment> GetBookAssignmentByUserId(int userId)
        {
            return BookAssignments.Where(ba => ba.AssignedUserId == userId);
        }

        [HttpPost]
        [Route("issue/book")]
        public IEnumerable<BookAssignment> IssueBook([FromBody] BookAssignment bookAssignment)
        {
            // while issuing the book, needs to decrement the availabe book count in book context.
            BookAssignments.Add(bookAssignment);
            // needs to return id newly added row
            return BookAssignments;
        }

        [HttpPut("return/{assignmentId:int}/book")]
        public IEnumerable<BookAssignment> ReturnBook(int assignmentId)
        {
            // while returning the book, needs to increment the availabe book count in book context.
            var assignmentIndex = BookAssignments.FindIndex(ba => ba.Id == assignmentId);
            if(assignmentIndex >= 0)
            {
                BookAssignments[assignmentIndex].AssignmentStatus = AssignmentStatus.Returned;
            }

            return BookAssignments;
        }
    }
}
