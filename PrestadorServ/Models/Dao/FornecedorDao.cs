using AcessoDados.BaseRepository;
using PrestadorServ.Models.Entity;
using PrestadorServ.Models.IDao;

namespace PrestadorServ.Models.Dao
{
    public class FornecedorDao : BaseDaoRepository<Fornecedor>, IFornecedorDao
    {
    }
}