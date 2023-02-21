using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers
{
    public abstract class ConsumerBase<T> : IConsumerBase<T> where T : ConsumerModel
    {

        private readonly ILogger<ConsumerBase<T>> _logger;
        private readonly IRabbitUtils _rabbitUtils;
        private readonly string _queueName;

        public ConsumerBase(ILogger<ConsumerBase<T>> logger,
            IRabbitUtils rabbitUtils,
            string queueName)
        {
            _queueName = queueName;
            _logger = logger;
            _rabbitUtils = rabbitUtils;
        }

        public void Execute() 
        {
            var channel = _rabbitUtils.channel;

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                try
                {
                    _logger.LogInformation("Mensagem recebida" + nameof(T));

                    byte[] body = ea.Body.ToArray();

                    var message = Encoding.UTF8.GetString(body);

                    _logger.LogInformation(message);

                    var targetObject = JsonSerializer.Deserialize<T>(message);

                    if (!targetObject.Validar())
                    {
                        _logger.LogError($"Mensagem nao valida");
                        channel.BasicAck(ea.DeliveryTag, false);
                    }

                    ConsumerAction(targetObject);

                    channel.BasicAck(ea.DeliveryTag, false);

                    _logger.LogInformation("Sucesso processando a message" + nameof(T));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }

            };
            channel.BasicConsume(queue: _queueName,
                                 autoAck: false,
                                 consumer: consumer);
        }

        public abstract void ConsumerAction(T targetObject);
    }
}
