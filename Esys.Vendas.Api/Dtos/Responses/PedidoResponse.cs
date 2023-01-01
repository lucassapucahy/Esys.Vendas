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

        public PedidoResponse(int id, List<ProdutoResponse> produtos, decimal valorTotal, DateTime dataCriacao, DateTime dataAlteracao, StatusPedidoEnum statusPedido)
        {
            Id = id;
            Produtos = produtos;
            ValorTotal = valorTotal;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            this.statusPedido = statusPedido;
        }
    }
}
