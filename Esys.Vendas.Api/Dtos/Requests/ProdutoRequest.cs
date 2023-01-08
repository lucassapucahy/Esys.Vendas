using Esys.Vendas.Domain.DomainEntity;

namespace Esys.Vendas.Api.Dtos.Requests
{
    public class ProdutoRequest
    {
        public ProdutoRequest(string nome, decimal valorUnitario, string descricao, int quantidade, int id)
        {
            Nome = nome;
            ValorUnitario = valorUnitario;
            Descricao = descricao;
            Quantidade = quantidade;
            Id = id;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public Produto ConverterParaDominio() 
        {
            return new Produto(Nome,ValorUnitario,Descricao,Quantidade,Id);
        }
    }
}
