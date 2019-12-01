using System.Collections.Generic;

namespace Inventory.Infrastructure.Entities
{
    public class Category : EnityBase
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }

        public override bool IsNew()
        {
            return this.CategoryId == 0;
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

    }
}
