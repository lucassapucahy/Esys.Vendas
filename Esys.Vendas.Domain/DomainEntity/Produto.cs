namespace Esys.Vendas.Domain.DomainEntity
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public string Descricao { get; private set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }
        public virtual Pedido? Pedido { get; set; }

        public Produto(string nome, decimal valorUnitario, string descricao, int quantidade, int PedidoId)
        {
            Nome= nome;
            ValorUnitario= valorUnitario;
            Descricao= descricao;
            Quantidade = quantidade;
        }

        private Produto()
        {
        }

    }
}
