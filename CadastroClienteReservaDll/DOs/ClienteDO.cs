using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadastroClienteReservaDll.DOs
{
    public class ClienteDO : BaseDO
    {
        [Required]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = "";

        [StringLength(11, ErrorMessage = "O documento deve ter no máximo 11 caracteres (CPF).")]
        public string? Documento { get; set; }

        [StringLength(13, ErrorMessage = "O telefone deve ter no máximo 13 caracteres.")]
        public string? Telefone { get; set; }
    }
}