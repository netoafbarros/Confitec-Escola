USE [dbEscola]
GO

/****** Object:  Table [dbo].[UsuarioHistoricoEscolar]    Script Date: 23/12/2023 14:47:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsuarioHistoricoEscolar](
	[IdUsuarioHistoricoEscolar] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdHistoricoEscolar] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioHistoricoEscolar] PRIMARY KEY CLUSTERED 
(
	[IdUsuarioHistoricoEscolar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


