using System;
using System.Collections.Generic;

namespace BooksEntities
{
    public partial class Author
    {
        public Author()
        {
            AuthorsOfBooks = new HashSet<AuthorOfBook>();
        }

        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Email { get; set; }

        public ICollection<AuthorOfBook> AuthorsOfBooks { get; set; }
    }
}
