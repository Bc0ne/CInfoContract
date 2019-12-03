namespace Contract.Core.SubjectRole
{
    using System.Threading.Tasks;

    public interface ISubjectRoleRepository
    {
        Task<SubjectRole> GetSubjectRoleByCustomerAndContractCodeAsync(string customerCode, string contractCode);
    }
}
