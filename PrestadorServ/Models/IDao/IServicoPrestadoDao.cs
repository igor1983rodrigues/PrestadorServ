using System.Collections.Generic;
using AcessoDados.BaseInterface;
using PrestadorServ.Models.Entity;

namespace PrestadorServ.Models.IDao
{
    public interface IServicoPrestadoDao : IBaseDaoInterface<ServicoPrestado>
    {
        IEnumerable<ServicoPrestado> ObterServicoPrestado(object parametros, string strConexao);
        IEnumerable<object> MeloresConsumidores(string strConexao);
        IEnumerable<object> MediaServicosPorFornecedorTipo(string strConexao);
        IEnumerable<object> FornecedoresSemResultados(string strConexao);
    }
}
