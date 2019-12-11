namespace Contract.Core.SubjectRole
{
    using System;
    using Contract;

    public class SubjectRole : DomainEntity
    {
        public string CustomerCode { get; private set; }
        public CustomerRole RoleOfCustomer { get; private set; }
        public Money GuranateeAmount { get; private set; }
        public long ContractId { get; private set; }
        public virtual Contract Contract { get; private set; }

        public static SubjectRole New(string customerCode,
            CustomerRole roleOfCustomer,
            Money guaranteeAmount)
        {

            if (customerCode is null)
            {
                throw new ArgumentNullException(nameof(customerCode));
            }

            return new SubjectRole
            {
                CreationTime = DateTime.Now,
                CustomerCode = customerCode,
                RoleOfCustomer = roleOfCustomer,
                GuranateeAmount = guaranteeAmount
            };
        }
    }
}
