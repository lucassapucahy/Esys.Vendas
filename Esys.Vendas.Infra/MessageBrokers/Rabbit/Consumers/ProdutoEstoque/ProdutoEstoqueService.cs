using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers.ProdutoEstoque
{
    public class ProdutoEstoqueService : BackgroundService
    {
        private readonly ILogger<ProdutoEstoqueService> _logger;
        private readonly IProdutoEstoqueConsumer _consumer;

        public ProdutoEstoqueService(ILogger<ProdutoEstoqueService> logger,
            IRabbitUtils rabbitUtils, IProdutoEstoqueConsumer consumer)
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
