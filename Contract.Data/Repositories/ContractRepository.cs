using Contract.Core.Contract;
using Contract.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Data.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ContractDbContext _context;

        public ContractRepository(ContractDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddRangeOfContractsAsync(List<Core.Contract.Contract> contracts)
        {
            await _context.Contracts.AddRangeAsync(contracts);
            _context.SaveChanges();
        }
    }
}
