using System;

namespace LibraryManagement.Models
{
    public class BookAssignment
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int AssignedUserId { get; set; }

        public AssignmentStatus AssignmentStatus { get; set; }

        public DateTime AssignmentDate { get; set; }
    }
}
