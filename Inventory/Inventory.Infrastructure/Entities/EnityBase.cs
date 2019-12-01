using static Inventory.Infrastructure.Enums.Enumerators;

namespace Inventory.Infrastructure.Entities
{
    //public interface IEnityBase
    //{
    //    bool IsNew();
    //    bool IsValid();
    //}
    public abstract class EnityBase
    {
        public ActiveState ActiveStateId { get; set; }
        public abstract bool IsNew();
        public abstract bool IsValid();
    }
}
