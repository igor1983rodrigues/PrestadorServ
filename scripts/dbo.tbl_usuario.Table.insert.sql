USE [prest_serv]
GO

INSERT INTO [dbo].[tbl_usuario]
           ([id_fornecedor]
           ,[login_usuario]
           ,[senha_usuario])
		   select	f.id_fornecedor,
					'fornecedor' + cast(f.id_fornecedor as varchar(10)),
					'1234'
		   from dbo.tbl_fornecedor f
GO

