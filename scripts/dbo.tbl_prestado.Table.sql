USE [prest_serv]
GO
/****** Object:  Table [dbo].[tbl_prestado]    Script Date: 26/03/2019 16:22:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_prestado](
	[id_prestado] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_fornecedor] [int] NOT NULL,
	[id_tipo_serv] [int] NOT NULL,
	[desc_prestado] [text] NULL,
	[dt_atend_prestado] [datetime] NOT NULL,
	[valor_prestado] [money] NOT NULL,
 CONSTRAINT [PK_tbl_prestado] PRIMARY KEY CLUSTERED 
(
	[id_prestado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbl_prestado]  WITH CHECK ADD  CONSTRAINT [FK_tbl_prestado_tbl_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[tbl_cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[tbl_prestado] CHECK CONSTRAINT [FK_tbl_prestado_tbl_cliente]
GO

ALTER TABLE [dbo].[tbl_prestado]  WITH CHECK ADD  CONSTRAINT [FK_tbl_prestado_tbl_fornecedor] FOREIGN KEY([id_fornecedor])
REFERENCES [dbo].[tbl_fornecedor] ([id_fornecedor])
GO
ALTER TABLE [dbo].[tbl_prestado] CHECK CONSTRAINT [FK_tbl_prestado_tbl_fornecedor]
GO

ALTER TABLE [dbo].[tbl_prestado]  WITH CHECK ADD  CONSTRAINT [FK_tbl_prestado_tbl_tipo_serv] FOREIGN KEY([id_tipo_serv])
REFERENCES [dbo].[tbl_tipo_serv] ([id_tipo_serv])
GO
ALTER TABLE [dbo].[tbl_prestado] CHECK CONSTRAINT [FK_tbl_prestado_tbl_tipo_serv]
GO
