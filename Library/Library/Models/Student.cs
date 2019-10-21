using System.Collections.Generic;

namespace Library.Models
{
    public class Student : Entity
    {
        public string FullName { get; set; }
        public ICollection<BookStudent> Books { get; set; }
    }
}
