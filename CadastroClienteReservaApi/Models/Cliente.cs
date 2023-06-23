using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClienteReservaApi.Models
{
    public class Cliente : BaseModel
    {
        public string Nome { get; set; } = "";
        public string? Documento { get; set; }
        public string? Telefone { get; set; }
    }
}