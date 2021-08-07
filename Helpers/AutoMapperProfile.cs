using ApiREST.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApiREST.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IdentityRole, Roles>();
            CreateMap<IdentityUser, Usuarios>();
            CreateMap<Usuarios, IdentityUser>();
        }
    }
}