MERGE INTO [dbo].[Authors] AS Target
USING (VALUES
    (N'{07DA1BF3-CCDA-485A-8577-0EC8731661C7}', N'David Sceppa'),
    (N'{57DBA979-EFD1-4D92-BC97-0693A1FC2449}', N'Tim Patrick'),
    (N'{00BC7722-0158-4DC2-862F-1DD1658F0A14}', N'Murach'),
    (N'{024ED6FC-817C-43D0-A565-AB38EEBD345D}', N'Bill Wagner'),
    (N'{482AE61A-BB7D-4F8A-B730-74335D6505E3}', N'Jason Roberts'),
    (N'{818FA337-61CE-40F0-8EFE-65F43D8E8991}', N'Marco Russo'),
    (N'{B0C4F5BB-8B7B-49CE-84F8-5D148DC43CE3}', N'Paolo Pialorsi')
) AS Source ([AuthorId], [Name])
ON Target.[AuthorId] = Source.[AuthorId]
WHEN NOT MATCHED BY TARGET THEN
    -- Insert new rows
    INSERT ([AuthorId], [Name])
    VALUES ([AuthorId], [Name])
WHEN NOT MATCHED BY SOURCE THEN
    -- Delete rows
    DELETE;
GO
