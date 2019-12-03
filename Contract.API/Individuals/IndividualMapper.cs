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
                .ForPath(dest => dest.CurrentBalance.Currency, opt =>
                opt.MapFrom(src => src.ContractData.CurrentBalanceCurrency.ToString()))
                .ForPath(dest => dest.CurrentBalance.Value, opt =>
                opt.MapFrom(src => src.ContractData.CurrentBalanceValue))
                .ForPath(dest => dest.OriginalAmount.Currency, opt =>
                opt.MapFrom(src => src.ContractData.OriginalAmountCurrency.ToString()))
                .ForPath(dest => dest.OriginalAmount.Value, opt =>
                opt.MapFrom(src => src.ContractData.OriginalAmountValue))
                .ForPath(dest => dest.InstallmentAmount.Currency, opt =>
                opt.MapFrom(src => src.ContractData.InstallmentlAmountCurrency.ToString()))
                .ForPath(dest => dest.InstallmentAmount.Value, opt =>
                opt.MapFrom(src => src.ContractData.InstallmentAmountValue))
                .ForPath(dest => dest.OverdueBalance.Currency, opt =>
                opt.MapFrom(src => src.ContractData.OverdueBalanceCurrency.ToString()))
                .ForPath(dest => dest.OverdueBalance.Value, opt =>
                opt.MapFrom(src => src.ContractData.OverdueBalanceValue))
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
                .ForPath(dest => dest.SumOfOriginalAmount.Currency, opt =>
                opt.MapFrom(src => src.OriginalAmountCurrency.ToString()))
                .ForPath(dest => dest.SumOfOriginalAmount.Value, opt =>
                opt.MapFrom(dest => dest.OriginalAmountValue))
                .ForPath(dest => dest.SumInstallmentAmount.Currency, opt =>
                opt.MapFrom(src => src.InstallmentlAmountCurrency.ToString()))
                .ForPath(dest => dest.SumInstallmentAmount.Value, opt =>
                opt.MapFrom(dest => dest.InstallmentAmountValue))
                .ForPath(dest => dest.MaxOfOverdueBalance.Currency, opt =>
                opt.MapFrom(src => src.OverdueBalanceCurrency.ToString()))
                .ForPath(dest => dest.MaxOfOverdueBalance.Value, opt =>
                opt.MapFrom(src => src.OverdueBalanceValue));
        }
    }
}
