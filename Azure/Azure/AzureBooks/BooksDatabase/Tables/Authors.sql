CREATE TABLE [dbo].[Authors]
(
    [AuthorId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [Name] NVARCHAR(50) NOT NULL,
    [BirthDay] DATETIME2(0) NULL,
    [Email] [dbo].[Email] NULL,
    [DeathDay] DATETIME2(0) NOT NULL
)



GO

CREATE INDEX [IX_Authors_BirthDay] ON [dbo].[Authors] ([BirthDay])
