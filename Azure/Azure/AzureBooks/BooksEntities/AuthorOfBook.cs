using System;
using System.Collections.Generic;

namespace BooksEntities
{
    public partial class AuthorOfBook
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
