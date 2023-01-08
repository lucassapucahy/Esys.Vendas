using Esys.Vendas.Domain.DomainEntity;
using Esys.Vendas.Domain.Interfaces;
using Esys.Vendas.Domain.Interfaces.UseCase;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Esys.Vendas.Domain.UseCases
{
    public class CriarNovoPedidoUseCase : ICriarNovoPedidoUseCase
    {
        private readonly IProdutoEstoqueRepositorio _produtoEstoqueRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly ILogger<CriarNovoPedidoUseCase> _logger;

        public CriarNovoPedidoUseCase(IProdutoEstoqueRepositorio produtoEstoqueRepositorio, IPedidoRepositorio pedidoRepositorio, ILogger<CriarNovoPedidoUseCase> logger)
        {
            _produtoEstoqueRepositorio = produtoEstoqueRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
            _logger = logger;
        }

        public async Task<ResultsDomain<Pedido>> Execute(Pedido pedido) 
        {
            _logger.LogInformation($"Validando Pedido {JsonSerializer.Serialize(pedido)}");

            var validado = pedido.Validar();

            if (!validado)
            {
                _logger.LogError("Pedido inválido.");
                return ResultsDomain<Pedido>.ResultsDomainErroBuilder("Pedido inválido.");
            }

            var validacaoEstoque = await ValidarEstoque(pedido);

            if (!validacaoEstoque.Success) 
            {
                _logger.LogError(validacaoEstoque.ErrorMessage);
                return ResultsDomain<Pedido>.ResultsDomainErroBuilder(validacaoEstoque.ErrorMessage);
            }

            _logger.LogInformation($"Validado com sucesso");

            var pedidoSalvo = await _pedidoRepositorio.Adicionar(pedido);
            await _pedidoRepositorio.SalvarAlteracoes();

            return ResultsDomain<Pedido>.ResultsDomainSuccessBuilder(pedidoSalvo);
        }

        private async Task<ResultsDomain<Pedido>> ValidarEstoque(Pedido pedido) 
        {

            var produtoEstoque = (await _produtoEstoqueRepositorio.BuscarTodos()).Where(x => pedido.Produtos.Select(z => z.ProdutoEstoqueId).Contains(x.ProdutoId));

            foreach (var produto in pedido.Produtos)
            {
                var produtoEstoqueAlvo = produtoEstoque.FirstOrDefault(x => x.ProdutoId == produto.ProdutoEstoqueId);

                if (produtoEstoqueAlvo == null)
                {
                    _logger.LogError("Produto inexistente no estoque.");
                    return ResultsDomain<Pedido>.ResultsDomainErroBuilder("Produto inexistente no estoque.");
                }

                var quantidadeValida = produtoEstoqueAlvo.Validar(produto.Quantidade);

                if (!quantidadeValida)
                {
                    _logger.LogError("Produto faltando no estoque.");
                    return ResultsDomain<Pedido>.ResultsDomainErroBuilder("Produto faltando no estoque.");
                }
            }
            return ResultsDomain<Pedido>.ResultsDomainSuccessBuilder(pedido);
        }
    }
}
