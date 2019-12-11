namespace Contract.Core.Contract
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IContractRepository
    {
        Task AddRangeOfContractsAsync(List<Contract> contracts);
    }
}
