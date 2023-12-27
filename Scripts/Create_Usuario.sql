USE [dbEscola]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 23/12/2023 14:45:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Sobrenome] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[IdEscolaridade] [int] NOT NULL,
 CONSTRAINT [Usuario_PK] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [Usuario_FK] FOREIGN KEY([IdEscolaridade])
REFERENCES [dbo].[Escolaridade] ([IdEscolaridade])
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [Usuario_FK]
GO


