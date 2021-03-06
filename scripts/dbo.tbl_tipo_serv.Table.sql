USE [prest_serv]
GO
/****** Object:  Table [dbo].[tbl_tipo_serv]    Script Date: 26/03/2019 16:22:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tipo_serv](
	[id_tipo_serv] [int] IDENTITY(1,1) NOT NULL,
	[nome_tipo_serv] [varchar](32) NOT NULL,
 CONSTRAINT [PK_tbl_tipo_serv] PRIMARY KEY CLUSTERED 
(
	[id_tipo_serv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert [dbo].[tbl_tipo_serv] ([nome_tipo_serv])
		select	'Conserto eletrônico'
union	select'serviços gerais'
union	select'manutenção hidráulica'
union	select'instalação elétrica'
union	select'jardinagem'
GO