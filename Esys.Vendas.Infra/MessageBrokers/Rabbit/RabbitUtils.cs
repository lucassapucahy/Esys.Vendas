using Esys.Vendas.Infra.MessageBrokers.Rabbit;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Esys.Vendas.Infra.Message
{
    public class RabbitUtils : IRabbitUtils
    {
        public IModel channel { get; set; }

        public RabbitUtils(IConfiguration configuration)
        {
            var rabbitUrl = configuration.GetSection("RabbitConnection:Url").Value;
            var rabbitPort = configuration.GetSection("RabbitConnection:Port").Value;

            var factory = new ConnectionFactory { HostName = rabbitUrl, Port = int.Parse(rabbitPort) };
            var connection = factory.CreateConnection();
             
            channel = connection.CreateModel();
        }

        public void Startup() 
        {
            UsuarioCriadoStartup();
        }

        private void UsuarioCriadoStartup()
        {
            channel.ExchangeDeclare(exchange: "UsuarioCriadoExchange", type: ExchangeType.Fanout);

            channel.QueueDeclare(queue: "Esys.UsuarioCriado",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            channel.QueueBind(queue: "Esys.UsuarioCriado",
                              exchange: "UsuarioCriadoExchange",
                              routingKey: string.Empty);
        }

    }
}
