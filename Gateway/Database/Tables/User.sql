CREATE TABLE [Auth].[User]
(
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_Auth_User] PRIMARY KEY CLUSTERED ([Id] ASC),
)
