namespace Contract.Web.Models.Contract
{
    using System;

    public class ContractOutputModel
    {
        public string PhaseOfContract { get; set; }
        public string SubjectRole { get; set; }
        public MoneyOutputModel OriginalAmount { get; set; }
        public MoneyOutputModel InstallmentAmount { get; set; }
        public MoneyOutputModel CurrentBalance { get; set; }
        public MoneyOutputModel OverdueBalance { get; set; }
        public DateTime? DateOfLastPayment { get; set; }
        public DateTime? NextPaymentDate { get; set; }
        public DateTime? DateAccountOpened { get; set; }
        public DateTime? RealEndDate { get; set; }
    }
}
