namespace Contract.Core.Individual
{
    using System.Threading.Tasks;

    public interface IIndividualRepository
    {
        Task<Individual> GetIndividualByNationalIdAsync(string nationalId);
    }
}
