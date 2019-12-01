namespace Inventory.Infrastructure.Enums
{
    public  class Enumerators
    {
        public enum ApprovalStatus
        {
            None = 0,
            Created = 1,
            NotifiedManager = 2,
            Approved = 3,
            Review = 4,
            Rejected = 5,
            Deleted = 6
        }

        public enum ActiveState
        {
            None = 0,
            Queued = 1,
            Active = 2,
            Deleted = 3
        }
    }
}
