namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers.UsuarioCriado
{
    public interface IUsuarioCriadoConsumer : IConsumerBase<UsuarioCriadoModel>
    {
        void ConsumerAction(UsuarioCriadoModel targetObject);
    }
}
