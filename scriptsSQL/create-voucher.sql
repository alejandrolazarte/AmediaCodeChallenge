USE [AmediaPeliculasDb]
GO

/****** Object:  Table [dbo].[Voucher]    Script Date: 15/07/2022 17:50:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Voucher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NULL,
	[SaleDate] [datetime] NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


