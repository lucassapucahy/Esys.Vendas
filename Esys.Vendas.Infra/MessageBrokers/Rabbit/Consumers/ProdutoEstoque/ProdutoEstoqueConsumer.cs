using Esys.Vendas.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers.ProdutoEstoque
{
    public class ProdutoEstoqueConsumer : ConsumerBase<ProdutoEstoqueModel>, IProdutoEstoqueConsumer
    {
        private readonly ILogger<ProdutoEstoqueConsumer> _logger;
        private readonly IProdutoEstoqueRepositorio _repositorio;

        public ProdutoEstoqueConsumer(ILogger<ProdutoEstoqueConsumer> logger, IRabbitUtils rabbitUtils, IProdutoEstoqueRepositorio repositorio)
            : base(logger, rabbitUtils, "Esys.ProdutoEstoque")
        {
            _logger = logger;
            _repositorio = repositorio;
        }

        public override async void ConsumerAction(ProdutoEstoqueModel targetObject)
        {
            var produtoEstoque = (await _repositorio.BuscarTodos()).FirstOrDefault(x => x.ProdutoId == targetObject.ProdutoId);

            if (produtoEstoque != null) 
            {
                produtoEstoque.QuantidadeEstoque = targetObject.QuantidadeEstoque;
                await _repositorio.Alterar(produtoEstoque);
                await _repositorio.SalvarAlteracoes();
                return;
            }

            var produtoEstoqueDomain = targetObject.ToDomain();
            await _repositorio.Adicionar(produtoEstoqueDomain);
            await _repositorio.SalvarAlteracoes();
            return;
        }
    }
}
