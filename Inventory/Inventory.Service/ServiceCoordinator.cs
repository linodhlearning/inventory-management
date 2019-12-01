using Inventory.Infrastructure;
using Inventory.Service.Interfaces;
using Inventory.Service.Services;
using System.Data;
using Inventory.Infrastructure.DTO;
using Microsoft.Extensions.DependencyInjection;
using Inventory.Infrastructure.Entities;

namespace Inventory.Service
{
    public class ServiceCoordinator : IServiceCoordinator
    { 
        private readonly string _connectionString;
        public IPersistenceRepository DomainRepository { get; set; }// WRITE REPOSITORY Uses different Lib (uses Entity F/W for now)
        //public ServiceCoordinator(string connectionString)
        //{
        //    this._connectionString = connectionString;
        //    this.DomainRepository = new PersistenceRepository(connectionString);  
        //}

        public ServiceCoordinator(InventoryContext inventoryContext) // todo remove the depedency on EF
        { 
            this.DomainRepository = new PersistenceRepository(inventoryContext);
        }

        private ICategoryService _category;
        public ICategoryService Category
        {
            get
            {
                //threadsafe but may not be singleton
                if (this._category == null)
                {
                    this._category = new CategoryService(this);
                }
                return this._category;
            }
        }
        private IProductService _product;
        public IProductService Product
        {
            get
            {
                //threadsafe but may not be singleton
                if (this._product == null)
                {
                    this._product = new ProductService(this);
                }
                return this._product;
            }
        }

        private IDbConnection _dbConnection;
        public IDbConnection DbConnection
        {
            get
            {
                if (_dbConnection == null || string.IsNullOrEmpty(this._connectionString))
                {
                    _dbConnection = this.DomainRepository.GetNewDbConnection();
                }
                return _dbConnection;
            }
        }

        public bool SaveChanges()
        {
            int affectedRecords = this.DomainRepository.SaveChanges();
            return affectedRecords > 0;
        }

    }
}
