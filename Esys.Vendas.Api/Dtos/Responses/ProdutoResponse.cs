namespace Esys.Vendas.Api.Dtos.Responses
{
    public class ProdutoResponse
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public string Descricao { get; private set; }
        public int Quantidade { get; set; }

        public ProdutoResponse(int id, string nome, decimal valorUnitario, string descricao, int quantidade)
        {
            Id = id;
            Nome = nome;
            ValorUnitario = valorUnitario;
            Descricao = descricao;
            Quantidade = quantidade;
        }
    }
}
