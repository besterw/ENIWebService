
/****** Object:  Table [dbo].[DataBaseUpgrade]    Script Date: 06/20/2012 18:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DataBaseUpgrade](
	[dbupd_ID] [int] IDENTITY(1,1) NOT NULL,
	[dbupd_UniqueId] [varchar](100) NULL,
	[dbupd_Revision] [varchar](100) NULL,
	[dbupd_DateApplied] [datetime] NULL,
	[dbupd_Source] [varchar](4000) NULL,
	[dbupd_SQL] [varchar](8000) NULL,
	[dbupd_Path] [varchar](255) NULL,
	[dbupd_FileName] [varchar](255) NULL,
	[dbupd_ExecutionResult] [varchar](8000) NULL,
 CONSTRAINT [PK_DataBaseUpgrade] PRIMARY KEY CLUSTERED 
(
	[dbupd_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


insert into dbo.DataBaseUpgrade(dbupd_Revision, dbupd_DateApplied, dbupd_FileName)
select 'R00000', getdate(), 'Update R00000.sql'
Go