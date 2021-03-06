USE [prest_serv]
GO
/****** Object:  Table [dbo].[tbl_fornecedor]    Script Date: 26/03/2019 16:22:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_fornecedor](
	[id_fornecedor] [int] IDENTITY(1,1) NOT NULL,
	[nome_fornecedor] [varchar](64) NOT NULL,
 CONSTRAINT [PK_tbl_fornecedor] PRIMARY KEY CLUSTERED 
(
	[id_fornecedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
