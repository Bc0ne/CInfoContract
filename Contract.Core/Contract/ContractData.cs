namespace Contract.Core.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ContractData : DomainEntity
    {
        public ContractPhase PhaseOfContract { get; set; }
        public decimal OriginalAmountValue { get; set; }
        public Currency OriginalAmountCurrency { get; set; }
        public decimal InstallmentAmountValue { get; set; }
        public Currency InstallmentlAmountCurrency { get; set; }
        public decimal CurrentBalanceValue { get; set; }
        public Currency CurrentBalanceCurrency { get; set; }
        public decimal OverdueBalanceValue { get; set; }
        public Currency OverdueBalanceCurrency { get; set; }
        public long ContractId { get; set; }
        public Contract Contract { get; set; }
        public DateTime DateOfLastPayment { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public DateTime DateAccountOpened { get; set; }
        public DateTime RealEndDate { get; set; }
    }
}
