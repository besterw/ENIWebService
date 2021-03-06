
CREATE TABLE [dbo].[ExspenseAccounts](
	[exac_Id] [int] IDENTITY(1,1) NOT NULL,
	[exac_UniqueId] [varchar](1000) NULL,
	[exac_Site] [int] NULL,
	[exac_Site_Guid] [varchar](1000) NULL,
	[exac_Group01] [varchar](1000) NULL,
	[exac_Group02] [varchar](1000) NULL,
	[exac_Group03] [varchar](1000) NULL,
	[exac_Name] [varchar](50) NULL,
	[exac_HasVat_YN] [varchar](1) NULL,
	[exac_Changed_YN] [varchar](1) NULL,
	[exac_sync_received] [varchar](4000) NULL
 CONSTRAINT [PK_ExspenseAccounts] PRIMARY KEY CLUSTERED 
(
	[exac_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF