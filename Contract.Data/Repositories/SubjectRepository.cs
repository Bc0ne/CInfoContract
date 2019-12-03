namespace Contract.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Contract.Data.Context;
    using Core.SubjectRole;
    using Microsoft.EntityFrameworkCore;

    public class SubjectRoleRepository : ISubjectRoleRepository
    {
        private readonly ContractDbContext _context;
        public SubjectRoleRepository(ContractDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<SubjectRole> GetSubjectRoleByCustomerAndContractCodeAsync(string customerCode, string contractCode)
        {
            return await _context.SubjectRole
                .Include(x => x.Contract)
                .Where(x => !x.IsDeleted && x.CustomerCode == customerCode && x.Contract.ContractCode == contractCode)
                .FirstOrDefaultAsync();
        }
    }
}
