namespace CadastroClienteReservaApi.Models

{
    public class ClienteReserva : BaseModel
    {
        public ClienteReserva() { }

        public ClienteReserva(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public string? IdCliente
        {
            get => cliente == null ? idCliente : cliente.Id;
            set => idCliente = value;
        }

        public DateTime DataReserva { get; set; }

        public int QuantidadePessoas { get; set; }

        private string? idCliente = null;
        private Cliente? cliente;
    }
}
