namespace Esys.Vendas.Domain.DomainEntity
{
    public class ProdutoEstoque
    {
        public int Id { get; private set; }
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        public ProdutoEstoque(int produtoId, Produto produto, int quantidadeEstoque)
        {
            ProdutoId = produtoId;
            Produto = produto;
            QuantidadeEstoque = quantidadeEstoque;
        }

        private ProdutoEstoque()
        {
        }
    }
}
