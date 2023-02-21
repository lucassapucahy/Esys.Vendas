namespace Esys.Vendas.Domain.DomainEntity
{
    public class ProdutoEstoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; private set; }
        public int QuantidadeEstoque { get; set; }

        public ProdutoEstoque(int produtoId, int quantidadeEstoque)
        {
            ProdutoId = produtoId;
            QuantidadeEstoque = quantidadeEstoque;
        }

        private ProdutoEstoque()
        {
        }

        public bool Validar(int quantidadePedido) 
        {
            return QuantidadeEstoque >= quantidadePedido;
        }
    }
}
