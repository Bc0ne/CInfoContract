namespace Contract.Core.Contract
{
    using System;

    public class ContractData : DomainEntity
    {
        public ContractPhase PhaseOfContract { get; private set; }
        public Money OriginalAmount { get; private set; }
        public Money InstallmentAmount { get; private set; }
        public Money CurrentBalance { get; private set; }
        public Money OverdueBalance { get; private set; }
        public DateTime? DateOfLastPayment { get; private set; }
        public DateTime? NextPaymentDate { get; private set; }
        public DateTime? DateAccountOpened { get; private set; }
        public DateTime? RealEndDate { get; private set; }
        public long ContractId { get; private set; }
        public virtual Contract Contract { get; private set; }

        public static ContractData New(Money originalAmount,
            Money installmentAmount,
            Money currentBalance,
            Money overdueBalance,
            DateTime? dateOfLastPayment,
            DateTime? nextPaymentDate,
            DateTime? dateAccountOpened,
            DateTime? realEndDate)
        {
            if (currentBalance is null)
            {
                throw new ArgumentNullException(nameof(CurrentBalance));
            }

            return new ContractData
            {
                CreationTime = DateTime.Now,
                OriginalAmount = originalAmount,
                InstallmentAmount = installmentAmount,
                CurrentBalance = currentBalance,
                OverdueBalance = overdueBalance,
                DateOfLastPayment = dateOfLastPayment,
                NextPaymentDate = nextPaymentDate,
                DateAccountOpened = dateAccountOpened,
                RealEndDate = realEndDate
            };
        }
    }
}
