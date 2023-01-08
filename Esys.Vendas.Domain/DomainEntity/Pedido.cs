using Esys.Vendas.Domain.Enum;

namespace Esys.Vendas.Domain.DomainEntity
{
    public class Pedido
    {
        public int Id { get; private set; }
        public virtual List<Produto> Produtos { get; private set; }
        public int UsuarioId { get; private set; }
        public virtual Usuario? Usuario { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public StatusPedidoEnum StatusPedido { get; private set; }

        public Pedido(int usuarioId)
        {
            Produtos = new List<Produto>();
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
            StatusPedido = StatusPedidoEnum.Analise;
            UsuarioId = usuarioId;
        }

        private Pedido()
        {
        }

        public bool AdicionarProdutos(List<Produto> produtos)
        {
            Produtos.AddRange(produtos);
            ValorTotal = produtos.Sum(x => x.ValorUnitario * x.Quantidade);
            return true;
        }

        public void AlterarParaAprovado()
        {
            StatusPedido = StatusPedidoEnum.Aprovado;
        }
        public void AlterarParaEnviado()
        {
            StatusPedido = StatusPedidoEnum.Enviado;
        }
        public void AlterarParaFinalizado()
        {
            StatusPedido = StatusPedidoEnum.Finalizado;
        }
        public void AlterarParaCancelado()
        {
            StatusPedido = StatusPedidoEnum.Cancelado;
        }

        public bool Validar() 
        {
           return Produtos.Count > 0 && UsuarioId > 0;
        }
    }
}
