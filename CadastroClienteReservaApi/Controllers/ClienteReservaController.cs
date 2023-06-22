using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroClienteReservaApi.Controllers.Extensoes;
using CadastroClienteReservaApi.DAOs;
using CadastroClienteReservaApi.Models;
using CadastroClienteReservaDll.DOs;

namespace CadastroClienteReservaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteReservaController : ControllerBase
    {
        // GET: api/ClienteReserva
        [HttpGet]
        public async Task<ActionResult<IList<ClienteReservaDO>>> Get()
        {
            return Ok((await dao.RetornarTodosAsync()).ToDO());
        }

        // GET: api/ClienteReserva
        [HttpGet("mestre/{idMestre}")]
        public async Task<ActionResult<IList<ClienteReservaDO>>> GetPorIdMestre(string idMestre)
        {
            return Ok((await dao.RetornarPorIdMestreAsync(idMestre)).ToDO());
        }

        // GET: api/ClienteReserva/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteReservaDO>> GetPorId(string id)
        {
            var objeto = await dao.RetornarPorIdAsync(id);

            if (objeto == null)
                return NotFound();

            return Ok(objeto.ToDO());
        }

        // POST: api/ClienteReserva
        [HttpPost]
        public async Task<ActionResult<ClienteReservaDO>> Post(ClienteReservaDO objDO)
        {
            if (objDO == null)
                return Problem("O record que você está tentando inserir está nulo.");

            var objeto = await objDO.ToModel();

            await dao.InserirAsync(objeto);

            objDO = objeto.ToDO();

            return CreatedAtAction(nameof(GetPorId), new { id = objDO.Id }, objDO);
        }

        // PUT: api/ClienteReserva/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ClienteReservaDO novoClienteReservaDO)
        {
            if (id != novoClienteReservaDO.Id)
                return Problem("Como você pode me enviar um id na rota diferente do id do objeto?");
            //return BadRequest();

            try
            {
                await dao.AlterarAsync(await novoClienteReservaDO.ToModel());
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/ClienteReserva/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await dao.ExcluirAsync(id);

            return NoContent();
        }

        private ClienteReservaDAO dao = new ClienteReservaDAO();
    }
}