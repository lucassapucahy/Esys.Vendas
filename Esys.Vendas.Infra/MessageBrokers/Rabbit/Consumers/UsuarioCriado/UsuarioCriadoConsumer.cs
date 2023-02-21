using Esys.Vendas.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers.UsuarioCriado
{
    public class UsuarioCriadoConsumer : ConsumerBase<UsuarioCriadoModel>, IUsuarioCriadoConsumer
    {
        private readonly ILogger<UsuarioCriadoConsumer> _logger;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioCriadoConsumer(ILogger<UsuarioCriadoConsumer> logger, IRabbitUtils rabbitUtils, IUsuarioRepositorio usuarioRepositorio)
            : base(logger, rabbitUtils, "Esys.UsuarioCriado")
        {
            _logger = logger;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public override async void ConsumerAction(UsuarioCriadoModel targetObject)
        {
            var usuarioDomain = targetObject.ToDomain();

            var usuarioAdicionado = await _usuarioRepositorio.Adicionar(usuarioDomain);
            await _usuarioRepositorio.SalvarAlteracoes();

            _logger.LogInformation($"Usuario {usuarioDomain.Nome} criado com sucesso com ID: {usuarioAdicionado.Id}");
        }
    }
}
