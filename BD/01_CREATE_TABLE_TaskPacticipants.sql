USE [AyE_Services]
GO
 
CREATE TABLE [dbo].[TaskPacticipants](
	[IdTaskPacticipants] [int] IDENTITY(1,1) NOT NULL,
	[IdTask] [int] NULL,
	[IdEmployee] [int] NULL,
	[State] [bit] NULL,
 CONSTRAINT [PK_TaskPacticipants] PRIMARY KEY CLUSTERED 
(
	[IdTaskPacticipants] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TaskPacticipants]  WITH CHECK ADD  CONSTRAINT [FK_TaskPacticipants_Employees] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employees] ([IdEmployee])
GO

ALTER TABLE [dbo].[TaskPacticipants] CHECK CONSTRAINT [FK_TaskPacticipants_Employees]
GO

ALTER TABLE [dbo].[TaskPacticipants]  WITH CHECK ADD  CONSTRAINT [FK_TaskPacticipants_Task] FOREIGN KEY([IdTask])
REFERENCES [dbo].[Task] ([IdTask])
GO

ALTER TABLE [dbo].[TaskPacticipants] CHECK CONSTRAINT [FK_TaskPacticipants_Task]
GO


