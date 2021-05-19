MERGE INTO [dbo].[Books] AS Target
USING (VALUES
     (N'{FDE8ACF0-4A0F-47B1-A765-3EB4F3290AC7}', N'Entity Framework 6 Recipes 2nd Edition', NULL, '2012-05-05 00:00:01'),
     (N'{492B9F26-2282-46AB-A7D5-2EBDA991EC7F}', N'Introducing Microsoft LINQ', NULL, '2012-05-05 00:00:02'),
     (N'{B2F335F5-D5BB-43A0-A812-12C55157142B}', N'Microsoft ADO.NET', NULL, '2013-10-23 00:00:03'),
     (N'{08E98004-0551-4EEC-8208-3021CB75760A}', N'Programming Microsoft ADO.NET 4', NULL, '2013-10-23 00:00:04'),
     (N'{818FA337-61CE-40F0-8EFE-65F43D8E8991}', N'ADO.NET 4 database programming', NULL, '2013-10-23 00:00:05'),
     (N'{561B5ACE-4C6A-4EA0-9005-09CB9F325926}', N'Effective C#', NULL, '2015-09-01 00:00:06'),
     (N'{07DBD8CB-5F59-4FDA-B96B-B1F59DE9BC07}', N'LINQ Succinctly', NULL, '2015-09-01 00:00:07'),
     (N'{7E4A937F-EAC1-443D-9BB6-E3715539F188}', N'Programming Microsoft ADO.NET 4', NULL, '2015-09-01 00:00:08')
) AS Source ([BookId], [Name], [Description], [DateReleased])
ON Target.[BookId] = Source.[BookId]
WHEN MATCHED THEN
    UPDATE SET Target.[DateReleased] = Source.[DateReleased]
WHEN NOT MATCHED BY TARGET THEN
    -- Insert new rows
    INSERT ([BookId], [Name], [Description], [DateReleased])
    VALUES ([BookId], [Name], [Description], [DateReleased])
WHEN NOT MATCHED BY SOURCE THEN
    -- Delete rows
    DELETE;
GO