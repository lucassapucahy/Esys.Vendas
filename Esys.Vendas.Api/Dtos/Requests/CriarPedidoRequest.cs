using Esys.Vendas.Domain.DomainEntity;

namespace Esys.Vendas.Api.Dtos.Requests
{
    public class CriarPedidoRequest
    {
        public virtual List<ProdutoRequest> Produtos { get; set; }
        public int UsuarioId { get; set; }

        public Pedido ConverterParaDominio() 
        {
            var pedido = new Pedido(UsuarioId);
            pedido.AdicionarProdutos(Produtos.Select(x => x.ConverterParaDominio()).ToList());
            return pedido;
        }
    }
}
