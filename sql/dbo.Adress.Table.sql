USE [NGORobotics]
GO
/****** Object:  Table [dbo].[Adress]    Script Date: 3/24/2018 11:34:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adress](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Lat] [float] NOT NULL,
	[Long] [float] NOT NULL,
	[AddressDetails] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
