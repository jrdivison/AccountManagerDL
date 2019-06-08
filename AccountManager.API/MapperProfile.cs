using AccountManager.API.Security;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.API
{
    public class MapperProfile
        : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUser, IdentityUser>()
                .ForMember(d => d.Id, opt => 
                    opt.MapFrom(s=> Guid.NewGuid().ToString()))
                .ForMember(d => d.NormalizedUserName, 
                    opt => opt.MapFrom(s => s.NormalizedUserName))
                .ForMember(d => d.UserName, opt => 
                    opt.MapFrom(s => s.UserName))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForAllOtherMembers(d=> d.Ignore());

        }
    }
}
