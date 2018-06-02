USE [ContactDB]
GO

/****** Object:  Table [dbo].[Status]    Script Date: 6/2/2018 3:47:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Status](
	[Id] [int] NOT NULL,
	[StatusDescription] [nchar](20) NOT NULL,
	[StatusValue] [char](1) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[Status] VALUES (1, 'Active', 'A')
GO
INSERT INTO [dbo].[Status] VALUES (2, 'Inctive', 'I')
GO

USE [ContactDB]
GO

/****** Object:  Table [dbo].[Contact]    Script Date: 6/2/2018 3:47:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](30) NULL,
	[PhoneNumber] [bigint] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_Status] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Id])
GO

ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_Status]
GO


