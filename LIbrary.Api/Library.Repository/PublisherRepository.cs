using Library.Domain;
using Library.Infra.Repository.DbConfiguration;
using System.Data;

namespace Library.Infra.Repository
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(IDatabaseFactory databaseOptions) : base(databaseOptions)
        {
        }
        public PublisherRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }
    }
}
