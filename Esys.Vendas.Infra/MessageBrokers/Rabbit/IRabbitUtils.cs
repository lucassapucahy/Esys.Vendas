using RabbitMQ.Client;

namespace Esys.Vendas.Infra.MessageBrokers.Rabbit
{
    public interface IRabbitUtils
    {
        IModel channel { get; set; }
        void Startup();
    }
}
