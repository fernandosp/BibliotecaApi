using System.Data;

namespace Library.Infra.Repository.DbConfiguration
{
    public interface IDatabaseFactory
    {
        IDbConnection GetDbConnection { get; }
    }
}