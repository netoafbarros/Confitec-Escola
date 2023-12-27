USE [dbEscola]
GO

/****** Object:  Table [dbo].[Escolaridade]    Script Date: 23/12/2023 14:46:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Escolaridade](
	[IdEscolaridade] [int] IDENTITY(1,1) NOT NULL,
	[Escolaridade] [nvarchar](40) NOT NULL,
 CONSTRAINT [escolaridade_PK] PRIMARY KEY CLUSTERED 
(
	[IdEscolaridade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


