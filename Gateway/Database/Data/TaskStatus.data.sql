SET IDENTITY_INSERT [Task].[EntityStatus] ON
MERGE INTO [Task].[EntityStatus] AS Target USING (VALUES
	(1,'Not Assigned'), 
	(2,'Assigned'), 
	(3,'In Review'),
	(4,'Completed')
)	AS Source ([Id],[Name]) ON Target.[Id]=Source.[Id]
	WHEN MATCHED AND Source.[Name] <> Target.[Name] COLLATE Latin1_General_CS_AS THEN
	UPDATE SET [Name]=Source.[Name]
	WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id],[Name])
	VALUES ([Id],[Name]);

SET IDENTITY_INSERT [Task].[TaskStatus] OFF