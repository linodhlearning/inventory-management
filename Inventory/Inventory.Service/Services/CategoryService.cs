using System.Collections.Generic;
using System.Data;
using System.Linq;
using Inventory.Infrastructure.Entities;
using Inventory.Service.Interfaces;
using Dapper;
using Inventory.Infrastructure.DTO;
using static Inventory.Infrastructure.Enums.Enumerators;

namespace Inventory.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IServiceCoordinator _serviceCoordinator;

        public CategoryService(IServiceCoordinator serviceCoordinator)
        {
            this._serviceCoordinator = serviceCoordinator;
        }

        public IEnumerable<CategoryDTO> GetActiveCategories()
        {
            var list = new List<CategoryDTO>();
            using (IDbConnection connection = this._serviceCoordinator.DbConnection)
            {
                connection.Open();
                list = connection.Query<CategoryDTO>("SELECT * FROM dbo.CategoryDTO WHERE ActiveStateId=@ActiveStateId", new { ActiveStateId = ActiveState.Active }).ToList();
                connection.Close();
            }
            return list;
        }

        public CategoryDTO GetById(int id)
        {
            CategoryDTO category = null;
            using (var connection = this._serviceCoordinator.DbConnection)
            {
                connection.Open();
                category = connection.Query<CategoryDTO>("SELECT * FROM Category WHERE CategoryId=@Id", new { Id = id }).SingleOrDefault();
                connection.Close();
            }
            return category;
        }

        public bool Save(CategoryDTO categoryDto)
        {
            Category categoryInDb = this.GetByIdToEdit(categoryDto.Id) ?? new Category();
            //todo: AutoMap 
            categoryInDb.Name = categoryDto.Name;
            categoryInDb.Description = categoryDto.Description;

            if (categoryInDb.IsNew())
            {
                this._serviceCoordinator.DomainRepository.Add(categoryInDb);
            }
            return this._serviceCoordinator.SaveChanges();
        }

        private Category GetByIdToEdit(int id)
        {
            return this._serviceCoordinator.DomainRepository.GetAll<Category>().SingleOrDefault(a => a.CategoryId == id);
        }
    }
}
