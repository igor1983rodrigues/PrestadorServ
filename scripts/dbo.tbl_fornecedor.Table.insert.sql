USE [prest_serv]
GO

INSERT INTO [dbo].[tbl_fornecedor] ([nome_fornecedor])
		select 'Fornecedor 1'
union	select 'Fornecedor 2'
union	select 'Fornecedor 3'
union	select 'Fornecedor 4'
union	select 'Fornecedor 5'
union	select 'Fornecedor 6'
union	select 'Fornecedor 7'
union	select 'Fornecedor 8'
GO

