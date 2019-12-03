namespace Contract.Web.Models.Individual
{
    using global::Contract.Web.Models.Contract;

    public class IndividualDetailsOutputModel
    {
        public IndividualOutputModel IndividualInformation { get; set; }
        = new IndividualOutputModel();
        public ContractOutputModel ContractInformation { get; set; }
        = new ContractOutputModel();
        public SummaryInformation SummaryInformation { get; set; }
        = new SummaryInformation();
    }
}
