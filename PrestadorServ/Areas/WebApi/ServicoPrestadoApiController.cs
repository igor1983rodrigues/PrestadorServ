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
                    cliente = cliente,
                    uf = uf,
                    cidade = cidade,
                    bairro = bairro,
                    tipoServ = tipoServ,
                    valMin = valMin,
                    valMax = valMax,
                    dtMin = dtMin,
                    dtMax = dtMax
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
                var res = await Task.Run(() => new { id = 0, nome = "teste", diferencial = "não sei" });
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
                return Ok(new { Id = id, Message = mensagem });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> PutItem([FromBody]object obj)
        {
            try
            {
                await Task.Run(() => Console.WriteLine(obj));
                return Ok(new
                {
                    Message = "TUdo deu certo!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("")]
        public async Task<IHttpActionResult> DeleteItem([FromBody]object obj)
        {
            try
            {
                await Task.Run(() => Console.WriteLine(obj));
                return Ok(new
                {
                    Message = "TUdo deu certo!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}