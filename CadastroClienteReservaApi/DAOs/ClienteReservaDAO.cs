using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroClienteReservaApi.Models;

namespace CadastroClienteReservaApi.DAOs
{
    public class ClienteReservaDAO : AutoDAO<ClienteReserva>
    {
        protected override string Tabela => "cliente_reserva";

        protected override string? NomeCampoIdMestre => "IdCliente";
    }
}