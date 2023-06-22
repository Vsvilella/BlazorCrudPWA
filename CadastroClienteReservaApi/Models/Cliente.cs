using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClienteReservaApi.Models
{
    public class Cliente : BaseModel
    {
        public string Nome { get; set; } = "";

        public double Documento { get; set; }

        public double Telefone { get; set; }
    }
}