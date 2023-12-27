USE [dbEscola]
GO

/****** Object:  Table [dbo].[HistoricoEscolar]    Script Date: 23/12/2023 14:46:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HistoricoEscolar](
	[IdHistoricoEscolar] [int] IDENTITY(1,1) NOT NULL,
	[Formato] [nvarchar](4) NULL,
	[Nome] [nvarchar](200) NOT NULL,
	[Arquivo] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_HistoricoEscolar] PRIMARY KEY CLUSTERED 
(
	[IdHistoricoEscolar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


