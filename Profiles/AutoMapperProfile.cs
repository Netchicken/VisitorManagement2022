using AutoMapper;

using VisitorManagement.Models;

namespace VisitorManagement.Profiles
{
    public class AutoMapperProfile : Profile
    {
        //load the mappings into the constructor
        //https://code-maze.com/automapper-net-core/

        public AutoMapperProfile()
        {
            CreateMap<VisitorDTO, Visitor>();

            CreateMap<StaffNamesDTO, StaffNames>()
            .ForMember(
                  dest => dest.Id,
                  opt => opt.MapFrom(src => src.Id)
              )
              .ForMember(
                  dest => dest.Name,
                  opt => opt.MapFrom(src => src.Name)
              )
              .ForMember(
                  dest => dest.Department,
                  opt => opt.MapFrom(src => src.Department)
              )

              .ForMember(
                  dest => dest.VisitorCount,
                  opt => opt.MapFrom(src => src.VisitorCount)
              )
              .ReverseMap();

            CreateMap<List<StaffNamesDTO>, List<StaffNames>>();

        }

    }
}
