CREATE TABLE [Task].[TaskStatus]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_Task_TaskStatus] PRIMARY KEY CLUSTERED ([Id] ASC),

)
