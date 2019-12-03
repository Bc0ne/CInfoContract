namespace Contract.Web.Models.Contract
{
    public class SummaryInformation
    {
        public MoneyOutputModel SumOfOriginalAmount { get; set; }
        public MoneyOutputModel SumInstallmentAmount { get; set; }
        public MoneyOutputModel MaxOfOverdueBalance { get; set; }
    }
}
