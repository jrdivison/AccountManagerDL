using System;
using System.Collections.Generic;
using System.Text;
using AccountManager.Data.Models;
using AccountManager.Data.Models.DTO;
using AutoMapper;

namespace AccountManager.Data
{
    public class MapperProfile
        : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccountType, ViewModelParent<int>>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Description, opt => 
                    opt.MapFrom(s => $"{s.Code} - {s.Name}" ));

            CreateMap<AccountType, AccountTypeDTO>();
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, Account>();

            CreateMap<AccountDTO, Account>()
               .ForMember(d => d.AccountType, opt => opt.Ignore())
               .ForMember(d => d.RowVersion, opt => opt.Ignore());

            CreateMap<AccountTypeDTO, AccountType>()
                .ForMember(d=>d.Accounts, opt=>opt.Ignore())
                .ForMember(d => d.RowVersion, opt => opt.Ignore());
        }
    }
}
