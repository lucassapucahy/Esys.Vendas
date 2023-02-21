namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers
{
    public interface IConsumerBase<T>
    {
        void Execute();
        void ConsumerAction(T targetObject);
    }
}
