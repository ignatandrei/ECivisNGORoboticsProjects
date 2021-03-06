USE [NGORobotics]
GO
/****** Object:  Table [dbo].[RoboticEntityProjects]    Script Date: 24.03.2018 15:34:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoboticEntityProjects](
	[IDRoboticEntity] [bigint] NOT NULL,
	[IDProjects] [bigint] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RoboticEntityProjects]  WITH CHECK ADD  CONSTRAINT [FK_RoboticEntityProjects_Projects] FOREIGN KEY([IDProjects])
REFERENCES [dbo].[Projects] ([ID])
GO
ALTER TABLE [dbo].[RoboticEntityProjects] CHECK CONSTRAINT [FK_RoboticEntityProjects_Projects]
GO
ALTER TABLE [dbo].[RoboticEntityProjects]  WITH CHECK ADD  CONSTRAINT [FK_RoboticEntityProjects_RoboticEntity] FOREIGN KEY([IDRoboticEntity])
REFERENCES [dbo].[RoboticEntity] ([ID])
GO
ALTER TABLE [dbo].[RoboticEntityProjects] CHECK CONSTRAINT [FK_RoboticEntityProjects_RoboticEntity]
GO
