
namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers.ProdutoEstoque
{
    public class ProdutoEstoqueModel: ConsumerModel
    {
        public int ProdutoId { get; set; }
        public int QuantidadeEstoque { get; set; }


        public override bool Validar()
        {
            return
                ProdutoId > 0
                && QuantidadeEstoque > 0;
                
        }

        public Domain.DomainEntity.ProdutoEstoque ToDomain() 
        {
            return new Domain.DomainEntity.ProdutoEstoque(ProdutoId,QuantidadeEstoque);
        }
    }
}
