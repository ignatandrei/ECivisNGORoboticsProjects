USE [NGORobotics]
GO
/****** Object:  Table [dbo].[RoboticEntity]    Script Date: 3/24/2018 11:34:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoboticEntity](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[IDAdress] [bigint] NOT NULL,
 CONSTRAINT [PK_RoboticEntity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RoboticEntity]  WITH CHECK ADD  CONSTRAINT [FK_RoboticEntity_Adress] FOREIGN KEY([IDAdress])
REFERENCES [dbo].[Adress] ([ID])
GO
ALTER TABLE [dbo].[RoboticEntity] CHECK CONSTRAINT [FK_RoboticEntity_Adress]
GO
