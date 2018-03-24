USE [NGORobotics]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 24.03.2018 15:34:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
