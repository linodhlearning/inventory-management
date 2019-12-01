using System.Data;

namespace Inventory.Service.Interfaces
{
    public interface IServiceCoordinator
    {
        bool SaveChanges();

        IDbConnection DbConnection { get; }
        IPersistenceRepository DomainRepository { get; }

        ICategoryService Category { get; }
        IProductService Product { get; }
    }
}
