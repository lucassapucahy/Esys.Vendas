using Esys.Vendas.Domain.DomainEntity;
using Esys.Vendas.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Esys.Vendas.Domain.UseCases
{
    public class CriarNovoPedidoUseCase
    {
        private readonly IProdutoEstoqueRepositorio _produtoEstoqueRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly ILogger<CriarNovoPedidoUseCase> _logger;

        public async Task<Pedido?> Execute(Pedido pedido) 
        {
            _logger.LogInformation($"Validando Pedido {JsonSerializer.Serialize(pedido)}");
            var produtoEstoque = (await _produtoEstoqueRepositorio.BuscarTodos()).Where(x => pedido.Produtos.Select(z => z.Id).Contains(x.ProdutoId));

            var validado = pedido.Validar();

            if (!validado)
            {
                _logger.LogError("Pedido invalido.");
                return null;
            }

            _logger.LogInformation($"Validado com sucesso");

            var pedidoSalvo = await _pedidoRepositorio.Adicionar(pedido);
            await _pedidoRepositorio.SalvarAlteracoes();

            return pedidoSalvo;
        }
    }
}
