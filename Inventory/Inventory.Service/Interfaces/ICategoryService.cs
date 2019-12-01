using Inventory.Infrastructure.DTO; 
using System.Collections.Generic;
namespace Inventory.Service.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetActiveCategories();
        CategoryDTO GetById(int id);
        bool Save(CategoryDTO categoryDto);
    }
}
