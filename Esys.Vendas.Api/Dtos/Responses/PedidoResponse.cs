using Esys.Vendas.Domain.DomainEntity;
using Esys.Vendas.Domain.Enum;

namespace Esys.Vendas.Api.Dtos.Responses
{
    public class PedidoResponse
    {
        public int Id { get; private set; }
        public List<ProdutoResponse> Produtos { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public StatusPedidoEnum statusPedido { get; private set; }

        public PedidoResponse(int id, decimal valorTotal, DateTime dataCriacao, DateTime dataAlteracao, StatusPedidoEnum statusPedido)
        {
            Id = id;
            ValorTotal = valorTotal;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            this.statusPedido = statusPedido;
            Produtos = new List<ProdutoResponse>();
        }

        public static PedidoResponse CriarApartirDominio(Pedido pedido)
        {
            var pedidoResponse = new PedidoResponse(pedido.Id,pedido.ValorTotal,pedido.DataCriacao,pedido.DataAlteracao,pedido.StatusPedido);
            pedidoResponse.Produtos.AddRange(pedido.Produtos.Select(x => ProdutoResponse.CriarApartirDominio(x)));
            return pedidoResponse;
        }
    }
}
