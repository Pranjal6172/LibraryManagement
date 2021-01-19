using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public enum Languages
    {
        English = 0,
        Hindi,
        Tamil,
        Gujrati,
    }

    public enum GenreType
    {
        Comic = 0,
        Drama,
        Fantasy,
        Scientific,
        Historic,
    }

    public enum AssignmentStatus
    {
        Issued = 0,
        Returned = 1,
    }
}
