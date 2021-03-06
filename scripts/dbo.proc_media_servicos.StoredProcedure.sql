USE [prest_serv]
GO
/****** Object:  StoredProcedure [dbo].[proc_media_servicos]    Script Date: 28/03/2019 16:55:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[proc_media_servicos] as
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
	id_fornecedor		int			null,
	id_tipo_serv		int			null,
	media				money		null
);

while @i < @mesAtual
BEGIN
	set @i = @i + 1;
	if @i > 9 
		set @dataInicial = CONVERT(DATE, @ano + CAST(@i as varchar(2)) + '01' ,112);
	else
		set @dataInicial = CONVERT(DATE, @ano + '0' + CAST(@i as varchar(2)) + '01' ,112);

	set @dataFinal = DATEADD(MONTH, 1, DATEADD(DAY, -1, @dataInicial));

	insert	into #temp(mes, id_fornecedor, id_tipo_serv, media)
	select	tb.a as mes,
			tb.id_fornecedor,
			tb.id_tipo_serv,
			AVG(tb.valor_prestado) as Media
	from
	(select	MONTH(ServicoPrestado.dt_atend_prestado) as a,
			ServicoPrestado.id_fornecedor,
			ServicoPrestado.id_tipo_serv,
			ServicoPrestado.valor_prestado
	from	dbo.tbl_prestado as ServicoPrestado
	where	ServicoPrestado.dt_atend_prestado between @dataInicial and @dataFinal
	and		ServicoPrestado.dt_atend_prestado <= GETDATE()
	union	select
			@i as a,
			null as id_fornecedor,
			null as id_tipo_serv,
			0 as valor_prestado) as tb
	group	by
			a,
			tb.id_fornecedor,
			tb.id_tipo_serv
	order	by Media desc;
	end;

	select	
			Temp.id_fornecedor as IdFornecedor,
			Temp.id_tipo_serv as IdTipoServico,
			Temp.mes as MesTemp,
			Temp.media as MediaTemp,

			-- Tabela Fornecedor
			Fornecedor.id_fornecedor as IdFornecedor,
			Fornecedor.nome_fornecedor as NomeFornecedor,

			-- Tabela TipoServico
			TipoServico.id_tipo_serv as IdTipoServico,
			TipoServico.nome_tipo_serv as NomeTipoServico
	from	#temp as Temp
	left	join dbo.tbl_fornecedor as Fornecedor on Temp.id_fornecedor = Fornecedor.id_fornecedor
	left	join dbo.tbl_tipo_serv as TipoServico on Temp.id_tipo_serv = TipoServico.id_tipo_serv;

end
GO
