namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers.ProdutoEstoque
{
    public interface IProdutoEstoqueConsumer : IConsumerBase<ProdutoEstoqueModel>
    {
        void ConsumerAction(ProdutoEstoqueModel targetObject);
    }
}
