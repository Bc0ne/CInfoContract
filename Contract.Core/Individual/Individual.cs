namespace Contract.Core.Individual
{
    using System;
    using Contract;

    public class Individual : DomainEntity
    {
        public string CustomerCode { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public Gender? Gender { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public string NationalId { get; private set; }
        public long ContractId { get; private set; }
        public virtual Contract Contract { get; private set; }

        public static Individual New(string customerCode,
            string firstName,
            string lastName,
            Gender? gender,
            DateTime? dateOfBirth,
            string nationalId)
        {
            if (customerCode is null)
            {
                throw new ArgumentException(nameof(customerCode));
            }

            if (firstName is null)
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if(lastName is null)
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            return new Individual
            {
                CreationTime = DateTime.Now,
                CustomerCode = customerCode,
                Firstname = firstName,
                Lastname = lastName,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                NationalId = nationalId
            };
        }
    }
}
