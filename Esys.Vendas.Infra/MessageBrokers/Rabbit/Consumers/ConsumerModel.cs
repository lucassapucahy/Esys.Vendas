namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers
{
    public abstract class ConsumerModel
    {
        public int ErrorMessage { get; protected set; }
        public abstract bool Validar();
    }
}
