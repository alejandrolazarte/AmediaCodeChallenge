USE [AmediaPeliculasDb]
GO

/****** Object:  Table [dbo].[VoucherDetail]    Script Date: 15/07/2022 17:51:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VoucherDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NULL,
	[VoucherId] [int] NULL,
 CONSTRAINT [PK_VoucherDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VoucherDetail]  WITH CHECK ADD  CONSTRAINT [FK_VoucherDetail_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO

ALTER TABLE [dbo].[VoucherDetail] CHECK CONSTRAINT [FK_VoucherDetail_Movie]
GO

ALTER TABLE [dbo].[VoucherDetail]  WITH CHECK ADD  CONSTRAINT [FK_VoucherDetail_Voucher] FOREIGN KEY([VoucherId])
REFERENCES [dbo].[Voucher] ([Id])
GO

ALTER TABLE [dbo].[VoucherDetail] CHECK CONSTRAINT [FK_VoucherDetail_Voucher]
GO


