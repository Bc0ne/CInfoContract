namespace Contract.API.Individuals
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Contract.Core.Individual;
    using Contract.Core.SubjectRole;
    using Contract.Web.Models;
    using Contract.Web.Models.Contract;
    using Contract.Web.Models.Individual;
    using Microsoft.AspNetCore.Mvc;
    

    [Route("api/individuals")]
    [ApiController]
    public class IndividualController : Controller
    {
        private readonly IIndividualRepository _individualRepository;
        private readonly ISubjectRoleRepository _subjectRoleRepository;

        public IndividualController(IIndividualRepository individualRepository,
            ISubjectRoleRepository subjectRoleRepository)
        {
            _individualRepository = individualRepository ?? throw new ArgumentNullException(nameof(individualRepository));
            _subjectRoleRepository = subjectRoleRepository ?? throw new ArgumentNullException(nameof(subjectRoleRepository));
        }

        [HttpGet("{nationalId}/search")]
        public async Task<IActionResult> SearchIndividualByNationalId(string nationalId)
        {
            if (string.IsNullOrEmpty(nationalId))
            {
                return BadRequest(ResponseResult.Failed(ErrorCode.ValidationError, "National Id can't be empty."));
            }

            var individual = await _individualRepository.GetIndividualByNationalIdAsync(nationalId);

            if (individual is null)
            {
                return NotFound(ResponseResult.Failed(ErrorCode.Error, "no hit information"));
            }
             
            return Ok(ResponseResult.SucceededWithData("One Single hit"));
        }

        [HttpGet("{nationalId}")]
        public async Task<IActionResult> GetIndividualDetailsByNationalId(string nationalId)
        {
            if (string.IsNullOrEmpty(nationalId))
            {
                return BadRequest(ResponseResult.Failed(ErrorCode.ValidationError, "National Id can't be empty."));
            }

            var individual = await _individualRepository.GetIndividualByNationalIdAsync(nationalId);

            if (individual is null)
            {
                return NotFound(ResponseResult.Failed(ErrorCode.Error, "Individual isn't found."));
            }

            var result = new IndividualDetailsOutputModel()
            {
                ContractInformation = Mapper.Map<ContractOutputModel>(individual.Contract),
                IndividualInformation = Mapper.Map<IndividualOutputModel>(individual),
                SummaryInformation = Mapper.Map<SummaryInformation>(individual.Contract.ContractData)
            };

            var subjectRole = await _subjectRoleRepository.GetSubjectRoleByCustomerAndContractCodeAsync(individual.CustomerCode,
                individual.Contract.ContractCode);

            result.ContractInformation.SubjectRole = subjectRole.RoleOfCustomer.ToString();
            return Ok(ResponseResult.SucceededWithData(result));
        }
    }
}