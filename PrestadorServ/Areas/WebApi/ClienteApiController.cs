using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace PrestadorServ.Areas.WebApi
{
    [RoutePrefix("api/cliente")]
    public class ClienteApiController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetListaAsync()
        {
            try
            {
                string[] res = await Task.Run(() => new string[] { "entrou" });
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
        public async Task<IHttpActionResult> PostItem([FromBody]object obj)
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