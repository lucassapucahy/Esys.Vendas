namespace Esys.Vendas.Api.Dtos.Requests
{
    public class ProdutoRequest
    {
        public ProdutoRequest(string nome, decimal valorUnitario, string descricao, int quantidade)
        {
            Nome = nome;
            ValorUnitario = valorUnitario;
            Descricao = descricao;
            Quantidade = quantidade;
        }

        public string Nome { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public string Descricao { get; private set; }
        public int Quantidade { get; set; }
    }
}
