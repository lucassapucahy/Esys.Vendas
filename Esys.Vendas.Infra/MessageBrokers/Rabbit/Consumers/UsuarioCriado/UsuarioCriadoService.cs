using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers.UsuarioCriado
{
    public class UsuarioCriadoService : BackgroundService
    {
        private readonly ILogger<UsuarioCriadoService> _logger;
        private readonly IUsuarioCriadoConsumer _consumer;

        public UsuarioCriadoService(ILogger<UsuarioCriadoService> logger,
            IRabbitUtils rabbitUtils, IUsuarioCriadoConsumer consumer)
        {
            _logger = logger;
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Execute();

            while (!stoppingToken.IsCancellationRequested)
                await Task.Delay(1000, stoppingToken);
        }
    }
}
