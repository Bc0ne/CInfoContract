namespace Contract.Core
{
    using System;

    public class DomainEntity
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
