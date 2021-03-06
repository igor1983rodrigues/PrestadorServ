USE [prest_serv]
GO
/****** Object:  StoredProcedure [dbo].[proc_maiores_clientes]    Script Date: 28/03/2019 16:55:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[proc_maiores_clientes] as
declare
	@i INT = 0,
	@ano varchar(4) = CAST(YEAR(GETDATE()) as varchar(4)),
	@mesAtual int = MONTH(GETDATE()),
	@mes varchar(16),
	@dataInicial DATE,
	@dataFinal DATE;
begin

create table #temp (
	mes					varchar(16) not null,
	id_cliente			int			null,
	total				money		null
);

while @i < @mesAtual

BEGIN
	set @i = @i + 1;
	if @i > 9 
		set @dataInicial = CONVERT(DATE, @ano + CAST(@i as varchar(2)) + '01' ,112);
	else
		set @dataInicial = CONVERT(DATE, @ano + '0' + CAST(@i as varchar(2)) + '01' ,112);

	set @dataFinal = DATEADD(MONTH, 1, DATEADD(DAY, -1, @dataInicial));

	insert	into #temp (mes, id_cliente, total)
	SELECT	top 3
			MONTH(t.dt_atend_prestado) mes,
			t.id_cliente,
			sum(t.valor_prestado) as total
	from	dbo.tbl_prestado t
	where	t.dt_atend_prestado between @dataInicial and @dataFinal
	and		t.dt_atend_prestado <= GETDATE()
	group	by t.id_cliente, MONTH(t.dt_atend_prestado)
	order	by
			mes asc,
			total desc;
END;

select	
		Temp.id_cliente as IdCliente,
		Temp.mes as MesTemp,
		Temp.total as TotalTemp,
		Cliente.id_cliente as IdCliente,
		Cliente.nome_cliente as NomeCliente,
		Cliente.bairro_cliente as BairroCliente,
		Cliente.cidade_cliente as CidadeCliente,
		Cliente.uf_cliente as UfCliente
from	#temp Temp
inner	join dbo.tbl_cliente as Cliente on Temp.id_cliente = Cliente.id_cliente;
--order	by t.mes asc, t.total;
end
GO
