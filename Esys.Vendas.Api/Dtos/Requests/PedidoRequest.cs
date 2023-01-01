namespace Esys.Vendas.Api.Dtos.Requests
{
    public class PedidoRequest
    {
        public virtual List<ProdutoRequest> Produtos { get; private set; }
        public int UsuarioId { get; private set; }
    }
}
