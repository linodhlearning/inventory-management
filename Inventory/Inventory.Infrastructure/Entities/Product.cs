using static Inventory.Infrastructure.Enums.Enumerators;

namespace Inventory.Infrastructure.Entities
{
    public class Product : EnityBase
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public ApprovalStatus ApprovalStatusId { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public override bool IsNew()
        {
            return this.ProductId == 0;
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(this.Name) &&
                this.UnitPrice > 0 &&
                this.ApprovalStatusId != ApprovalStatus.None;
        }
    }
}
