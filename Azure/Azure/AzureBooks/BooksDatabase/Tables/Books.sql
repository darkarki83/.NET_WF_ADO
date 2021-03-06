﻿CREATE TABLE [dbo].[Books]
(
    [BookId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [DateReleased] DATETIME2(0) NOT NULL,
    [ISBN] NVARCHAR(13) NULL
)
