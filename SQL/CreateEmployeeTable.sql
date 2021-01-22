USE [TASK]
GO

/****** Object:  Table [dbo].[employee]    Script Date: 22/01/2021 8:19:19 am ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[employee](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [varchar](50) NULL,
	[DOB] [date] NULL,
	[Gender] [varchar](50) NULL,
	[EmailId] [varchar](100) NULL,
	[Address] [varchar](100) NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


