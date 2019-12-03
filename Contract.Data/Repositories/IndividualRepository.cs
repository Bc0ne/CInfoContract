namespace Contract.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Contract.Core.Individual;
    using Contract.Data.Context;
    using Microsoft.EntityFrameworkCore;

    public class IndividualRepository : IIndividualRepository
    {
        private readonly ContractDbContext _context;
        public IndividualRepository(ContractDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Individual> GetIndividualByNationalIdAsync(string nationalId)
        {
            return await _context.Individuals
                .Include(x => x.Contract)
                .ThenInclude(x => x.ContractData)
                .FirstOrDefaultAsync(x => !x.IsDeleted && x.NationalId == nationalId);
        }
    }
}
