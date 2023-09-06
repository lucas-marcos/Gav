using AutoMapper;
using Gav.Models;
using Gav.Models.DTO;
using Gav.Models.TO;

namespace Gav.Mapping;

public class MappingProfile  : Profile
{
    public MappingProfile()
    {
        CreateMap<ApplicationUserCriarUsuarioDTO, ApplicationUser>();
        CreateMap<ApplicationUserLogarDTO, ApplicationUser>();
        CreateMap<ApplicationUser, ApplicationUserTO>();
    }
}