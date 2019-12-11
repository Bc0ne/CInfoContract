namespace Contract.Core.Individual
{
    using System.Threading.Tasks;
    using Contract;

    public interface IIndividualRepository
    {
        Task<Individual> GetIndividualByNationalIdAsync(string nationalId);
        Task<Contract> GetContractAsync(long id);
    }
}
