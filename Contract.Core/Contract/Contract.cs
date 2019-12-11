namespace Contract.Core.Contract
{
    using System;
    using System.Collections.Generic;
    using global::Contract.Core.SubjectRole;
    using Individual;

    public class Contract : DomainEntity
    {
        public string ContractCode { get; private set; }
        public virtual ContractData ContractData { get; private set; }
        public virtual IEnumerable<Individual> Individuals { get; private set; }
        public virtual IEnumerable<SubjectRole> SubjectRoles { get; private set; }

        public bool IsValid()
        {
            foreach (var ind in Individuals)
            {
                if (ind.DateOfBirth != null)
                {
                    var today = DateTime.Today;
                    var age = today.Year - ind.DateOfBirth.Value.Year;
                    if (ind.DateOfBirth.Value.Date > today.AddYears(-age))
                    {
                        age--;
                    }

                    if (age < 18 && age > 99)
                    {
                        return false;
                    }
                }
            }

            if (ContractData.DateOfLastPayment != null && ContractData.NextPaymentDate != null &&
                    DateTime.Compare(ContractData.DateOfLastPayment.Value, ContractData.NextPaymentDate.Value) >= 0)
            {
                return false;
            }

            if (ContractData.DateAccountOpened != null && ContractData.DateOfLastPayment != null &&
                DateTime.Compare(ContractData.DateAccountOpened.Value, ContractData.DateOfLastPayment.Value) >= 0)
            {
                return false;
            }

            if (SubjectRoles != null)
            {
                decimal? sum = 0;
                foreach (var role in SubjectRoles)
                {
                    if (role.GuranateeAmount != null && role.GuranateeAmount.Value != null)
                    {
                        sum += role.GuranateeAmount.Value;
                    }
                }

                if (sum >= ContractData.OriginalAmount.Value)
                {
                    return false;
                }
            }

            return true;
        }

        public static Contract New(string contractCode,
            ContractData contractData,
            List<Individual> individuals,
            List<SubjectRole> subjectRoles)
        {

            if (contractCode is null)
            {
                throw new ArgumentNullException(nameof(contractCode));
            }

            if (contractData is null)
            {
                throw new ArgumentNullException(nameof(contractData));
            }

            return new Contract
            {
                CreationTime = DateTime.Now,
                ContractCode = contractCode,
                ContractData = contractData,
                Individuals = individuals,
                SubjectRoles = subjectRoles
            };
        }
    }
}
