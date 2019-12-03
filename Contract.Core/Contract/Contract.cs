
namespace Contract.Core.Contract
{
    using System.Collections.Generic;
    using global::Contract.Core.SubjectRole;
    using Individual;

    public class Contract : DomainEntity
    {
        public string ContractCode { get; set; }
        public virtual ContractData ContractData { get; set; }
        public virtual IEnumerable<Individual> Individuals { get; set; }
        public virtual IEnumerable<SubjectRole> SubjectRoles { get; set; }
    }
}
