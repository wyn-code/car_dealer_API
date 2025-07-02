using AutoMapper;
using Car_DealerShip_Proyect.Models.Auto;
using Car_DealerShip_Proyect.Models.Auto.Dto;

namespace Car_DealerShip_Proyect.Config
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
            
            // teclado de membrana
        }
        
    }
}
