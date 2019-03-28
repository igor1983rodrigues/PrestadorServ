using Newtonsoft.Json.Linq;
using PrestadorServ.Models.Entity;
using PrestadorServ.Models.IDao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PrestadorServ.Areas.WebApi
{
    [RoutePrefix("api/prestado")]
    public class ServicoPrestadoApiController : ApiController
    {
        private IServicoPrestadoDao iServicoPrestadoDao;
        private string mensagem;

        public ServicoPrestadoApiController(IServicoPrestadoDao iServicoPrestadoDao)
        {
            this.iServicoPrestadoDao = iServicoPrestadoDao;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetLista(
            string fornecedor = null,
            string cliente = null,
            string uf = null,
            string cidade = null,
            string bairro = null,
            string tipoServ = null,
            decimal? valMin = null,
            decimal? valMax = null,
            DateTime? dtMin = null,
            DateTime? dtMax = null)
        {
            try
            {
                IEnumerable<ServicoPrestado> res = await Task.Run(() => iServicoPrestadoDao.ObterServicoPrestado(new
                {
                    Fornecedor = fornecedor,
                    Cliente = cliente,
                    Uf = uf,
                    Cidade = cidade,
                    Bairro = bairro,
                    TipoServ = tipoServ,
                    ValMin = valMin,
                    ValMax = valMax,
                    DtMin = dtMin,
                    DtMax = dtMax
                }, Properties.Resources.ProducaoConn));

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("fornecedor/{idFornecedor:int}")]
        public async Task<IHttpActionResult> GetListaPorFornecedor(
            int idFornecedor,
            string cliente = null,
            string uf = null,
            string cidade = null,
            string bairro = null,
            string tipoServ = null,
            decimal? valMin = null,
            decimal? valMax = null,
            DateTime? dtMin = null,
            DateTime? dtMax = null)
        {
            try
            {
                IEnumerable<ServicoPrestado> res = await Task.Run(() => iServicoPrestadoDao.ObterServicoPrestado(new
                {
                    IdFornecedor = idFornecedor,
                    Cliente = cliente,
                    Uf = uf,
                    Cidade = cidade,
                    Bairro = bairro,
                    TipoServ = tipoServ,
                    ValMin = valMin,
                    ValMax = valMax,
                    DtMin = dtMin,
                    DtMax = dtMax
                }, Properties.Resources.ProducaoConn));

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetItem(int id)
        {
            try
            {
                ServicoPrestado res = await Task.Run(() => iServicoPrestadoDao.ObterPorChave(id, Properties.Resources.ProducaoConn));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("maioresconsumidores")]
        public async Task<IHttpActionResult> ListarMelhoresClientesNoAno()
        {
            try
            {
                var res = await Task.Run(() => iServicoPrestadoDao.MeloresConsumidores(Properties.Resources.ProducaoConn));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("fornecedoressemresultado")]
        public async Task<IHttpActionResult> ListarFornecedoresSemResultados()
        {
            try
            {
                var res = await Task.Run(() => iServicoPrestadoDao.FornecedoresSemResultados(Properties.Resources.ProducaoConn));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("mediafornecedorestiposervico")]
        public async Task<IHttpActionResult> ListarMediaServicosPorFornecedorTipo()
        {
            try
            {
                var res = await Task.Run(() => iServicoPrestadoDao.MediaServicosPorFornecedorTipo(Properties.Resources.ProducaoConn));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Insert([FromBody]JObject modelo)
        {
            try
            {
                mensagem = null;
                ServicoPrestado servicoPrestado = modelo.ToObject<ServicoPrestado>();
                int id = await Task.Run(() => iServicoPrestadoDao.Inserir(servicoPrestado, out mensagem, Properties.Resources.ProducaoConn));
                if (!string.IsNullOrEmpty(mensagem))
                {
                    throw new Exception(mensagem);
                }
                return Ok(new { Id = id, Message = "Registro salvo com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody]JObject modelo)
        {
            try
            {
                mensagem = null;
                ServicoPrestado servicoPrestado = modelo.ToObject<ServicoPrestado>();
                servicoPrestado.IdServicoPrestado = id;
                await Task.Run(() => iServicoPrestadoDao.Alterar(servicoPrestado, out mensagem, Properties.Resources.ProducaoConn));
                if (!string.IsNullOrEmpty(mensagem))
                {
                    throw new Exception(mensagem);
                }
                return Ok(new { Id = id, Message = "Registro alterado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteItem(int id)
        {
            try
            {
                mensagem = null;
                await Task.Run(() => iServicoPrestadoDao.Excluir(id, out mensagem, Properties.Resources.ProducaoConn));

                if (!string.IsNullOrEmpty(mensagem))
                {
                    throw new Exception(mensagem);
                }
                return Ok(new { Id = id, Message = "Registro excluído com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}