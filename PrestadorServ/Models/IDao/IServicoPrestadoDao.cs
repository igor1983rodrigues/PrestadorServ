using System.Collections.Generic;
using AcessoDados.BaseInterface;
using PrestadorServ.Models.Entity;

namespace PrestadorServ.Models.IDao
{
    public interface IServicoPrestadoDao : IBaseDaoInterface<ServicoPrestado>
    {
        IEnumerable<ServicoPrestado> ObterServicoPrestado(object parametros, string strConexao);
    }
}
