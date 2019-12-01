using System; 
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Inventory.Service.Interfaces
{
    public interface IPersistenceRepository
    {
        string ConnectionString { get; }
        IDbConnection GetNewDbConnection();

        void Add<T>(T entity) where T : class;

        void Remove<T>(T entity) where T : class;

        int SaveChanges();

        IQueryable<T> GetAll<T>() where T : class;

        IQueryable<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
