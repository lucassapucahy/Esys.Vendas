namespace Esys.Vendas.Domain.DomainEntity
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public List<Pedido> Pedidos { get; set; }

        public Usuario(string nome)
        {
            Nome = nome;
        }

        private Usuario() 
        {
        }
    }
}
