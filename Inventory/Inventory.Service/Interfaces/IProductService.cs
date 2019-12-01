using Inventory.Infrastructure.Entities;
using System.Collections.Generic;
using Inventory.Infrastructure.DTO;
namespace Inventory.Service.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetActiveProducts();
        ProductDTO GetById(int id);
        bool Save(ProductDTO productDto);
    }
}
