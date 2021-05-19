CREATE TABLE [dbo].[AuthorsOfBooks]
(
    [BookId] UNIQUEIDENTIFIER NOT NULL,
    [AuthorId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_AuthorsOfBooks] PRIMARY KEY ([BookId], [AuthorId]), 
    CONSTRAINT [FK_AuthorsOfBooks_To_Books] FOREIGN KEY ([BookId]) REFERENCES [Books]([BookId])
        ON UPDATE CASCADE
        ON DELETE CASCADE, 
    CONSTRAINT [FK_AuthorsOfBooks_To_Authors] FOREIGN KEY ([AuthorId]) REFERENCES [Authors]([AuthorId])
        ON UPDATE CASCADE
        ON DELETE CASCADE
)
