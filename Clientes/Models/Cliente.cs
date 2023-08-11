namespace Clientes
{
    public class Cliente
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string? Email { get; set; }

        public DateTime? Create_Client { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public string? Endereco { get; set; }


    }
}
