USE [NGORobotics]
GO
/****** Object:  Table [dbo].[ContactDetails]    Script Date: 24.03.2018 15:34:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactDetails](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDPhoneNumbers] [bigint] NULL,
	[IDEmails] [bigint] NULL,
	[Website] [nvarchar](200) NULL,
	[IDSocial] [bigint] NULL,
 CONSTRAINT [PK_ContactDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContactDetails]  WITH CHECK ADD  CONSTRAINT [FK_ContactDetails_Emails] FOREIGN KEY([IDEmails])
REFERENCES [dbo].[Emails] ([ID])
GO
ALTER TABLE [dbo].[ContactDetails] CHECK CONSTRAINT [FK_ContactDetails_Emails]
GO
ALTER TABLE [dbo].[ContactDetails]  WITH CHECK ADD  CONSTRAINT [FK_ContactDetails_PhoneNumbers] FOREIGN KEY([IDPhoneNumbers])
REFERENCES [dbo].[PhoneNumbers] ([ID])
GO
ALTER TABLE [dbo].[ContactDetails] CHECK CONSTRAINT [FK_ContactDetails_PhoneNumbers]
GO
ALTER TABLE [dbo].[ContactDetails]  WITH CHECK ADD  CONSTRAINT [FK_ContactDetails_Social] FOREIGN KEY([IDSocial])
REFERENCES [dbo].[Social] ([ID])
GO
ALTER TABLE [dbo].[ContactDetails] CHECK CONSTRAINT [FK_ContactDetails_Social]
GO
