using AutoMapper;
using BewerbungAPP.Models;
using BewerbungAPP.ViewModels;
using BewerbungAPP.Models.Enums;

namespace BewerbungAPP.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping جداگانه
            CreateMap<Person, BewerberProfilViewModel>();
            CreateMap<Profil, BewerberProfilViewModel>();
            CreateMap<BewerberProfilModel, BewerberProfilViewModel>();
        }
    }
}
