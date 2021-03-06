USE [prest_serv]
GO
/****** Object:  StoredProcedure [dbo].[proc_fornecedor_sem_servico]    Script Date: 28/03/2019 16:55:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[proc_fornecedor_sem_servico] as
declare
	@i INT = 0,
	@ano varchar(4) = CAST(YEAR(GETDATE()) as VARCHAR(4)),
	@mesAtual int = MONTH(GETDATE()),
	@mes varchar(16),
	@dataInicial DATE,
	@dataFinal DATE;

begin

	create table #temp (
		mes					varchar(16) not null,
		id_fornecedor		int			null
	);

	while @i < @mesAtual
	BEGIN
		set @i = @i + 1;
		if @i > 9 
			set @dataInicial = CONVERT(DATE, @ano + CAST(@i as varchar(2)) + '01' ,112);
		else
			set @dataInicial = CONVERT(DATE, @ano + '0' + CAST(@i as varchar(2)) + '01' ,112);

		set @dataFinal = DATEADD(MONTH, 1, DATEADD(DAY, -1, @dataInicial));

		insert	into #temp(mes, id_fornecedor)
		select	@i,
				t.id_fornecedor
		from	dbo.tbl_fornecedor t
		where	t.id_fornecedor not in (
					select	u.id_fornecedor
					from	dbo.tbl_prestado u
					where	u.dt_atend_prestado between @dataInicial and @dataFinal
				)
		order	by t.nome_fornecedor;
	end;

	select	
			Temp.id_fornecedor as IdFornecedor,
			Temp.mes as MesTemp,
			Fornecedor.id_fornecedor as IdFornecedor,
			Fornecedor.nome_fornecedor as NomeFornecedor
	from	#temp as Temp
	left	join dbo.tbl_fornecedor as Fornecedor on Temp.id_fornecedor = Fornecedor.id_fornecedor
	order	by Temp.mes asc;

end
GO
