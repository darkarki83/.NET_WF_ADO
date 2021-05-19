using System;
using System.Collections.Generic;

namespace BooksEntities
{
    public partial class Book
    {
        public Book()
        {
            AuthorsOfBooks = new HashSet<AuthorOfBook>();
        }

        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateReleased { get; set; }
        public string Isbn { get; set; }

        public ICollection<AuthorOfBook> AuthorsOfBooks { get; set; }
    }
}
