using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using AcessoDados.BaseRepository;
using Newtonsoft.Json.Linq;
using PrestadorServ.Models.Bo;
using PrestadorServ.Models.Entity;
using PrestadorServ.Models.IDao;
using PrestadorServ.Models.Resources;

namespace PrestadorServ.Models.Dao
{
    public class ServicoPrestadoDao : BaseDaoRepository<ServicoPrestado>, IServicoPrestadoDao
    {
        public IEnumerable<object> FornecedoresSemResultados(string strConexao)
        {
            Func<dynamic, Fornecedor, dynamic> fnc = (obj, fornecedor) => new
            {
                Mes = new DateTime(DateTime.Today.Year, Convert.ToInt16(obj.MesTemp), 1)
                    .ToString("MMMM", CultureInfo.CurrentUICulture)
                    .ToUpper(),
                Fornecedor = fornecedor
            };

            IEnumerable<dynamic> res = ExecuteQuery(
                ServicoPrestadoSql.FornecedoresSemResultados,
                null,
                strConexao,
                fnc,
                new string[] { "IdFornecedor" },
                CommandType.StoredProcedure);

            return res.GroupBy(t => t.Mes).Select(t => new
            {
                Mes = t.Key,
                Dados = t.Select(u => u.Fornecedor)
            });
        }

        public IEnumerable<object> MediaServicosPorFornecedorTipo(string strConexao)
        {
            Func<dynamic, Fornecedor, TipoServico, object> fnc = (obj, fornecedor, tipoServico) => new
            {
                Mes = new DateTime(DateTime.Today.Year, Convert.ToInt16(obj.MesTemp), 1)
                    .ToString("MMMM", CultureInfo.CurrentUICulture)
                    .ToUpper(),
                Media = obj.MediaTemp,
                Fornecedor = fornecedor,
                TipoServico = tipoServico
            };

            IEnumerable<dynamic> res = ExecuteQuery(
                ServicoPrestadoSql.MediaServicosPorFornecedorTipo,
                null,
                strConexao,
                fnc,
                new string[] { "IdFornecedor", "IdTipoServico" },
                CommandType.StoredProcedure);

            return res;
            //    .GroupBy(t => t.Mes).Select(t => new
            //{
            //    Mes = t.Key,
            //    Dados = t.Select(u => new
            //    {
            //        u.Total,
            //        u.Cliente
            //    })
            //});
        }

        public IEnumerable<object> MeloresConsumidores(string strConexao)
        {
            Func<dynamic, Cliente, object> fnc = (obj, cliente) => new
            {
                Mes = new DateTime(DateTime.Today.Year, Convert.ToInt16(obj.MesTemp), 1)
                    .ToString("MMMM", CultureInfo.CurrentUICulture)
                    .ToUpper(),
                Total = obj.TotalTemp,
                Cliente = cliente
            };

            IEnumerable<dynamic> res = ExecuteQuery(
                ServicoPrestadoSql.MeloresConsumidores,
                null,
                strConexao,
                fnc,
                new string[] { "IdCliente" },
                CommandType.StoredProcedure);

            return res.GroupBy(t => t.Mes).Select(t => new
            {
                Mes = t.Key,
                Dados = t.Select(u => new
                {
                    u.Total,
                    u.Cliente
                })
            });
        }

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
