namespace Contract.Core.SubjectRole
{
    using Contract;
    using Individual;
    using System.Collections.Generic;

    public class SubjectRole : DomainEntity
    {
        public string CustomerCode { get; set; }
        public CustomerRole RoleOfCustomer { get; set; }
        public decimal GuaranteeAmountValue { get; set; }
        public Currency GuaranteeAmountCurrency { get; set; }
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
