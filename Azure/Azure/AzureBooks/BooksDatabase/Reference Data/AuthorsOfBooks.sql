﻿MERGE INTO [dbo].[AuthorsOfBooks] AS Target
USING (VALUES
    (N'{7E4A937F-EAC1-443D-9BB6-E3715539F188}', N'{07DA1BF3-CCDA-485A-8577-0EC8731661C7}'),
    (N'{08E98004-0551-4EEC-8208-3021CB75760A}', N'{57DBA979-EFD1-4D92-BC97-0693A1FC2449}'),
    (N'{818FA337-61CE-40F0-8EFE-65F43D8E8991}', N'{00BC7722-0158-4DC2-862F-1DD1658F0A14}'),
    (N'{561B5ACE-4C6A-4EA0-9005-09CB9F325926}', N'{024ED6FC-817C-43D0-A565-AB38EEBD345D}'),
    (N'{07DBD8CB-5F59-4FDA-B96B-B1F59DE9BC07}', N'{482AE61A-BB7D-4F8A-B730-74335D6505E3}'),
    (N'{492B9F26-2282-46AB-A7D5-2EBDA991EC7F}', N'{818FA337-61CE-40F0-8EFE-65F43D8E8991}'),
    (N'{B2F335F5-D5BB-43A0-A812-12C55157142B}', N'{07DA1BF3-CCDA-485A-8577-0EC8731661C7}'),
    (N'{492B9F26-2282-46AB-A7D5-2EBDA991EC7F}', N'{B0C4F5BB-8B7B-49CE-84F8-5D148DC43CE3}')
) AS Source ([BookId], [AuthorId])
ON Target.[BookId] = Source.[BookId] AND 
 Target.[AuthorId] = Source.[AuthorId] 
WHEN NOT MATCHED BY TARGET THEN
    -- Insert new rows
    INSERT ([BookId], [AuthorId])
    VALUES ([BookId], [AuthorId])
WHEN NOT MATCHED BY SOURCE THEN
    -- Delete rows
    DELETE;
GO
