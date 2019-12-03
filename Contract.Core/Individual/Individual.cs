namespace Contract.Core.Individual
{
    using System;
    using Contract;
    using SubjectRole;

    public class Individual : DomainEntity
    {
        public string CustomerCode { get; set; }
        public string NationalId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
