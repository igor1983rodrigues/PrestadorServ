using System;
using System.Collections.Generic;
using System.Data;
using AcessoDados.BaseRepository;
using PrestadorServ.Models.Bo;
using PrestadorServ.Models.Entity;
using PrestadorServ.Models.IDao;
using PrestadorServ.Models.Resources;

namespace PrestadorServ.Models.Dao
{
    public class ServicoPrestadoDao : BaseDaoRepository<ServicoPrestado>, IServicoPrestadoDao
    {
        public IEnumerable<ServicoPrestado> ObterServicoPrestado(object parametros, string strConexao)
        {
            Func<ServicoPrestado, Cliente, Fornecedor, TipoServico, ServicoPrestado> callBack = (servicoPrestado, cliente, fornecedor, tipoServico) =>
            {
                servicoPrestado.Cliente = cliente;
                servicoPrestado.Fornecedor = fornecedor;
                servicoPrestado.TipoServico = tipoServico;
                return servicoPrestado;
            };

            string[] map = new string[] { "IdCliente", "IdFornecedor", "IdTipoServico" };

            string servicoPrestadoSql = ServicoPrestadoSql.ObterServicoPrestado.Filtro(parametros);

            return ExecuteQuery(servicoPrestadoSql, parametros, strConexao, callBack, map);
        }
    }
}
