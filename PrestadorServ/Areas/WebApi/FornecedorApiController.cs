using PrestadorServ.Models.Entity;
using PrestadorServ.Models.IDao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PrestadorServ.Areas.WebApi
{
    [RoutePrefix("api/fornecedor")]
    public class FornecedorApiController : ApiController
    {
        private IFornecedorDao iFornecedorDao;

        public FornecedorApiController(IFornecedorDao iFornecedorDao)
        {
            this.iFornecedorDao = iFornecedorDao;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetListaAsync()
        {
            try
            {
                IEnumerable<Fornecedor> res = await Task.Run(() => iFornecedorDao.ObterTodos(Properties.Resources.ProducaoConn));
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
                var res = await Task.Run(() => new  { id = id, nome = "teste", diferencial = "não sei" });
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> PostItem([FromBody]object obj)
        {
            try
            {
                await Task.Run(() => Console.WriteLine(obj));
                return Ok(new {
                    Message = "TUdo deu certo!"
                });
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