using Esys.Vendas.Domain.DomainEntity;

namespace Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers.UsuarioCriado
{
    public class UsuarioCriadoModel: ConsumerModel
    {
        public string Nome { get; set; }

        public override bool Validar()
        {
            return !string.IsNullOrEmpty(Nome);
        }

        public Usuario ToDomain() 
        {
            return new Usuario(Nome);
        }
    }
}
