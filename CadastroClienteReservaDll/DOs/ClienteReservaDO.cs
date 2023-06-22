using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadastroClienteReservaDll.DOs
{
    public class ClienteReservaDO : BaseDO
    {
        public string? IdCliente { get; set; }

        [Required]
        [Range(1, 30,
        ErrorMessage = "A quantidade de pessoas deve ser superior a 1 e inferior a 30.")]
        public int QuantidadePessoas { get; set; }

        public DateTime DataReserva { get; set; }
    }
}