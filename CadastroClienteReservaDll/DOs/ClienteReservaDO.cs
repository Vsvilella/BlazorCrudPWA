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
        [StringLength(100, ErrorMessage = "A descrição do record deve ter no máximo 100 caracteres.")]
        public int QuantidadePessoas { get; set; }

        public DateTime DataReserva { get; set; }
    }
}