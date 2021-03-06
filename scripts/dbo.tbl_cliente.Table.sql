USE [prest_serv]
GO
/****** Object:  Table [dbo].[tbl_cliente]    Script Date: 26/03/2019 16:22:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nome_cliente] [varchar](64) NOT NULL,
	[bairro_cliente] [varchar](64) NOT NULL,
	[cidade_cliente] [varchar](64) NOT NULL,
	[uf_cliente] [varchar](2) NOT NULL,
 CONSTRAINT [PK_tbl_cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
