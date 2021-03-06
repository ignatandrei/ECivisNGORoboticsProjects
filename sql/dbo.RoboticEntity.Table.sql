USE [NGORobotics]
GO
/****** Object:  Table [dbo].[RoboticEntity]    Script Date: 24.03.2018 15:34:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoboticEntity](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[IDAddress] [bigint] NOT NULL,
	[IDCategory] [bigint] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[MemberCount] [bigint] NOT NULL,
	[Rating] [int] NULL,
	[IDContactDetails] [bigint] NOT NULL,
	[WomenPercentage] [float] NULL,
	[Sentiment] [int] NULL,
 CONSTRAINT [PK_RoboticEntity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RoboticEntity]  WITH CHECK ADD  CONSTRAINT [FK_RoboticEntity_Adress] FOREIGN KEY([IDAddress])
REFERENCES [dbo].[Address] ([ID])
GO
ALTER TABLE [dbo].[RoboticEntity] CHECK CONSTRAINT [FK_RoboticEntity_Adress]
GO
ALTER TABLE [dbo].[RoboticEntity]  WITH CHECK ADD  CONSTRAINT [FK_RoboticEntity_Category] FOREIGN KEY([IDCategory])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[RoboticEntity] CHECK CONSTRAINT [FK_RoboticEntity_Category]
GO
ALTER TABLE [dbo].[RoboticEntity]  WITH CHECK ADD  CONSTRAINT [FK_RoboticEntity_ContactDetails] FOREIGN KEY([IDContactDetails])
REFERENCES [dbo].[ContactDetails] ([ID])
GO
ALTER TABLE [dbo].[RoboticEntity] CHECK CONSTRAINT [FK_RoboticEntity_ContactDetails]
GO
