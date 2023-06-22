using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroClienteReservaApi.Controllers.Extensoes;
using CadastroClienteReservaApi.Models;
using CadastroClienteReservaApi.DAOs;
using CadastroClienteReservaDll.DOs;

namespace CadastroClienteReservaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IList<ClienteDO>>> Get()
        {
            return Ok((await dao.RetornarTodosAsync()).ToDO());
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDO>> GetPorId(string id)
        {
            var objeto = await dao.RetornarPorIdAsync(id);

            if (objeto == null)
                return NotFound();

            return Ok(objeto.ToDO());
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<ClienteDO>> Post(ClienteDO objDO)
        {
            if (objDO == null)
                return Problem("O Cliente que você está tentando inserir está nulo.");

            var objeto = await objDO.ToModel();

            await dao.InserirAsync(objeto);

            objDO = objeto.ToDO();

            return CreatedAtAction(nameof(GetPorId), new { id = objDO.Id }, objDO);
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ClienteDO novoClienteDO)
        {
            if (id != novoClienteDO.Id)
                return Problem("Como você pode me enviar um id na rota diferente do id do objeto?");
            //return BadRequest();

            try
            {
                await dao.AlterarAsync(await novoClienteDO.ToModel());
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await dao.ExcluirAsync(id);

            return NoContent();
        }

        private ClienteDAO dao = new ClienteDAO();
    }
}
