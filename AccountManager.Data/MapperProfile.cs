namespace AccountManager.Data
{
    using AccountManager.Data.Models;
    using AccountManager.Data.Models.DTO;
    using AutoMapper;

    public class MapperProfile
        : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccountType, ViewModelParent<int>>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Description, 
                opt => opt.MapFrom(s => $"{s.Code} - {s.Name}" ));

            CreateMap<AccountType, AccountTypeDTO>();
            CreateMap<AccountTypeDTO, AccountType>()
                .ForMember(d => d.Accounts, opt => opt.Ignore())
                .ForMember(d => d.RowVersion, opt => opt.Ignore());
        }
    }
}
