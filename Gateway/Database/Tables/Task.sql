CREATE TABLE [Task].[Task]
(
	[Id] INT IDENTITY (1, 1) NOT NULL ,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[DueDate] [datetime] NULL,
	[CreatedUserId] [int] NOT NULL,
	[AssigneeId] [int] NULL,
	[StatusId] [int] NOT NULL,
	CONSTRAINT [PK_Task_Task] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Task_Created_User] FOREIGN KEY ([CreatedUserId]) REFERENCES [Auth].[User] ([Id]),
	CONSTRAINT [FK_Task_Assignee_User] FOREIGN KEY ([AssigneeId]) REFERENCES [Auth].[User] ([Id]),
)
