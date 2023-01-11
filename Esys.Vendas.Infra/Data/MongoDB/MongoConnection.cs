using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Esys.Vendas.Infra.Data.MongoDB
{
    public abstract class MongoConnection
    {
        protected readonly MongoClient dbClient;

        protected MongoConnection(IConfiguration configuration)
        {
            dbClient = new MongoClient(configuration.GetConnectionString("VendasMongoDb"));
        }
    }
}
