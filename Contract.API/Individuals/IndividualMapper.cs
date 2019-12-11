namespace Contract.API.Individuals
{
    using AutoMapper;
    using Contract.Core.Individual;
    using Contract.Web.Models.Contract;
    using Contract.Web.Models.Individual;
    using Core.Contract;
    public class IndividualMapper : Profile
    {
        public IndividualMapper()
        {
            CreateMap<Contract, ContractOutputModel>()
                .ForMember(dest => dest.PhaseOfContract, opt =>
                opt.MapFrom(src => src.ContractData.PhaseOfContract.ToString()))
                .ForMember(dest => dest.SubjectRole, opt => opt.Ignore())
                .ForMember(dest => dest.OriginalAmount, opt =>
                opt.MapFrom(src => src.ContractData.OriginalAmount))
                .ForMember(dest => dest.InstallmentAmount, opt =>
                opt.MapFrom(src => src.ContractData.InstallmentAmount))
                .ForMember(dest => dest.CurrentBalance, opt =>
                opt.MapFrom(src => src.ContractData.CurrentBalance))
                .ForMember(dest => dest.OverdueBalance, opt =>
                opt.MapFrom(src => src.ContractData.OverdueBalance))
                .ForMember(dest => dest.DateAccountOpened, opt =>
                opt.MapFrom(src => src.ContractData.DateAccountOpened))
                .ForMember(dest => dest.DateOfLastPayment, opt =>
                opt.MapFrom(src => src.ContractData.DateOfLastPayment))
                .ForMember(dest => dest.RealEndDate, opt =>
                opt.MapFrom(src => src.ContractData.RealEndDate))
                .ForMember(dest => dest.NextPaymentDate, opt =>
                opt.MapFrom(src => src.ContractData.NextPaymentDate));

            CreateMap<Individual, IndividualOutputModel>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(x => x.Gender.ToString()));

            CreateMap<ContractData, SummaryInformation>()
                .ForMember(dest => dest.SumOfOriginalAmount, opt =>
                  opt.MapFrom(src => src.OriginalAmount))
                  .ForMember(dest => dest.SumOfOriginalAmount, opt =>
                  opt.MapFrom(src => src.InstallmentAmount))
                  .ForMember(dest => dest.SumInstallmentAmount, opt =>
                  opt.MapFrom(src => src.InstallmentAmount))
                  .ForMember(dest => dest.MaxOfOverdueBalance, opt =>
                  opt.MapFrom(src => src.OverdueBalance));
        }

        public static SummaryInformation CalculateSummary()
        {
            return null;
        }
    }
}
