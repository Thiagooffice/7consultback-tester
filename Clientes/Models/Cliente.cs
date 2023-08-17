namespace Clientes
{
    public class Cliente
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }
    }
}
