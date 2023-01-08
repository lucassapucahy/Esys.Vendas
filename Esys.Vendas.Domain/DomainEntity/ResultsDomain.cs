namespace Esys.Vendas.Domain.DomainEntity
{
    public class ResultsDomain<T>
    {
        public T? ReturnObject { get; private set; }
        public bool Success { get; private set; }
        public string? ErrorMessage { get; private set; }


        public static ResultsDomain<T> ResultsDomainErroBuilder(string errorMessage) 
        { 
            return new ResultsDomain<T>() { 
                ReturnObject = default(T),
                ErrorMessage = errorMessage,
                Success = false
            };
        }

        public static ResultsDomain<T> ResultsDomainSuccessBuilder(T objectResponse)
        {
            return new ResultsDomain<T>()
            {
                ReturnObject = objectResponse,
                ErrorMessage = null,
                Success = true
                
            };
        }
    }
}
