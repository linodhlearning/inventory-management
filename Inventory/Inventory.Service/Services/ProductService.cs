using System.Linq;
using Inventory.Infrastructure.Entities;
using Inventory.Service.Interfaces;
using Dapper;
using System.Data;
using System.Collections.Generic;
using static Inventory.Infrastructure.Enums.Enumerators;
using Inventory.Infrastructure.DTO;

namespace Inventory.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IServiceCoordinator _serviceCoordinator;

        public ProductService(IServiceCoordinator serviceCoordinator)
        {
            this._serviceCoordinator = serviceCoordinator;
        }

        public IEnumerable<ProductDTO> GetActiveProducts()
        {
            var list = new List<ProductDTO>();
            using (IDbConnection connection = this._serviceCoordinator.DbConnection)
            {
                connection.Open();
                list = connection.Query<ProductDTO>("SELECT * FROM dbo.Product  WHERE ActiveStateId=@ActiveStateId", new { ActiveStateId = ActiveState.Active }).ToList();
                connection.Close();
            }
            return list;
        }

        public ProductDTO GetById(int id)
        {
            ProductDTO product = null;
            using (var connection = this._serviceCoordinator.DbConnection)
            {
                connection.Open();
                product = connection.Query<ProductDTO>(@"SELECT * FROM Product p
                                INNER JOIN Category c ON c.CategoryId = p.CategoryId
                                WHERE p.ProductId=@Id", new { Id = id }).SingleOrDefault();
                connection.Close();
            }
            return product;
        }

        public bool Save(ProductDTO productDto)
        {
            Product productInDb = this.GetByIdToEdit(productDto.Id) ?? new Product { ApprovalStatusId = ApprovalStatus.Created };
            //todo: AutoMap 
            productInDb.Name = productDto.Name;
            productInDb.Description = productDto.Description;
            productInDb.UnitPrice = productDto.UnitPrice;
            if (productInDb.IsNew())
            {
                this._serviceCoordinator.DomainRepository.Add(productInDb);
            }
            return this._serviceCoordinator.SaveChanges();
        }

        private Product GetByIdToEdit(int id)
        {
            return this._serviceCoordinator.DomainRepository.GetAll<Product>().SingleOrDefault(a => a.ProductId == id);
        }
    }
}
