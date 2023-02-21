using Microsoft.Extensions.Logging;

namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers.UsuarioCriado
{
    public class UsuarioCriadoConsumer : ConsumerBase<UsuarioCriadoModel>, IUsuarioCriadoConsumer
    {
        private readonly ILogger<UsuarioCriadoConsumer> _logger;

        public UsuarioCriadoConsumer(ILogger<UsuarioCriadoConsumer> logger, IRabbitUtils rabbitUtils)
            :base(logger,rabbitUtils, "Esys.UsuarioCriado")
        {
            _logger = logger;
        }

        public override void ConsumerAction(UsuarioCriadoModel targetObject)
        {
            _logger.LogInformation("qwert");
        }
    }
}
