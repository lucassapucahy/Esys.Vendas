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
        public StatusPedidoEnum statusPedido { get; private set; }

        public Pedido(int usuarioId)
        {
            Produtos = new List<Produto>();
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
            statusPedido = StatusPedidoEnum.Analise;
            UsuarioId = usuarioId;
        }

        private Pedido()
        {
        }

        public bool AdicionarProdutos(List<Produto> produtos)
        {
            produtos.AddRange(produtos);
            ValorTotal = produtos.Sum(x => x.ValorUnitario * x.Quantidade);
            return true;
        }

        public void AlterarParaAprovado()
        {
            statusPedido = StatusPedidoEnum.Aprovado;
        }
        public void AlterarParaEnviado()
        {
            statusPedido = StatusPedidoEnum.Enviado;
        }
        public void AlterarParaFinalizado()
        {
            statusPedido = StatusPedidoEnum.Finalizado;
        }

        public bool Validar() 
        {
           return Produtos.Count > 0 && UsuarioId > 0;
        }
    }
}
