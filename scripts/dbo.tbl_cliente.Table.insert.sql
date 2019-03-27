USE [prest_serv]
GO

INSERT INTO [dbo].[tbl_cliente]
           ([nome_cliente]
           ,[bairro_cliente]
           ,[cidade_cliente]
           ,[cliente_uf])
           select 'Cliente 1', 'Centro', 'Jaragu� do Sul', 'SC'
		   union
		   select 'Cliente 2', 'Centro', 'Blumenau', 'SC'
		   union
		   select 'Cliente 3', 'Centro', 'Joinville', 'SC'
		   union
		   select 'Cliente 4', 'Coronel Veiga', 'Petr�polis', 'RJ'
		   union
		   select 'Cliente 5', 'Itaipava', 'Petr�polis', 'RJ'
		   union
		   select 'Cliente 6', 'Centro', 'S�o Paulo', 'SP'
		   union
		   select 'Cliente 7', 'Castanheira', 'Bel�m', 'PA'
		   union
		   select 'Cliente 8', 'Vila Nova', 'Caldas Novas', 'GO'
GO

