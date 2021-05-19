CREATE VIEW [dbo].[BooksWithAuthors]
	AS SELECT AOB.AuthorId, B.Name, B.Description FROM [Books] AS B
	   INNER JOIN [AuthorsOfBooks] AS AOB ON AOB.BookId = B.BookId
