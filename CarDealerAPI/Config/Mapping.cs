using AutoMapper;
using CarDealerAPI.Models.Auto;
using CarDealerAPI.Models.Auto.Dto;
using CarDealerAPI.Models.Tipo_Auto;
using CarDealerAPI.Models.Tipo_Auto.Dto;

namespace CarDealerAPI.Config
{
    public class Mapping : Profile
    {
        public Mapping() {
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<List<string>?, List<string>>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);

            CreateMap<Auto, AllAutoDTO>().ReverseMap();
            CreateMap<Auto, CreateAutoDTO>().ReverseMap();
            CreateMap<Auto, UpdateAutoDTO>().ForAllMembers(opts => {
                opts.Condition((src, dest, scrMember) => scrMember != null);
            });

            CreateMap<Auto, AllAutoDTO>()
            .ForMember(dest => dest.Tipo_Auto,
                opt => opt.MapFrom(src => src.Tipo_Auto.tipo_autos))
            .ForMember(dest => dest.Condicion,
                opt => opt.MapFrom(src => src.CondicionName.condicionName));

            // teclado de membrana
        }
        
    }
}
