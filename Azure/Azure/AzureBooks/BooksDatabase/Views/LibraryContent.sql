CREATE VIEW [dbo].[LibraryContent]
	AS SELECT B.Name AS Book, A.Name AS Author, B.Description FROM [Books] AS B
	   LEFT JOIN [AuthorsOfBooks] AS AOB ON B.BookId = AOB.BookId
	   LEFT JOIN [Authors] AS A ON AOB.AuthorId = a.AuthorId
