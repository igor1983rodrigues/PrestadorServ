USE [prest_serv]
GO
/****** Object:  Table [dbo].[tbl_usuario]    Script Date: 26/03/2019 16:22:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_usuario](
	[id_fornecedor] [int] NOT NULL,
	[login_usuario] [varchar](32) NOT NULL,
	[senha_usuario] [varchar](64) NOT NULL,
 CONSTRAINT [PK_tbl_usuario] PRIMARY KEY CLUSTERED 
(
	[id_fornecedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_tbl_usuario] UNIQUE NONCLUSTERED 
(
	[login_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_usuario]  WITH CHECK ADD  CONSTRAINT [FK_tbl_usuario_tbl_fornecedor] FOREIGN KEY([id_fornecedor])
REFERENCES [dbo].[tbl_fornecedor] ([id_fornecedor])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_usuario] CHECK CONSTRAINT [FK_tbl_usuario_tbl_fornecedor]
GO
