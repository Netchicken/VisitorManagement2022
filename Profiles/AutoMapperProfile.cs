using AutoMapper;

using VisitorManagement.Models;
using VisitorManagement.ViewModels;

namespace VisitorManagement.Profiles
{
    public class AutoMapperProfile : Profile
    {
        //load the mappings into the constructor
        //https://code-maze.com/automapper-net-core/
        //https://docs.automapper.org/en/latest/Dependency-injection.html#asp-net-core

        //put maps in the constructor
        public AutoMapperProfile()
        {
            //         source      destination
            //  CreateMap<Visitor, VisitorVM>().ReverseMap();

            //  CreateMap<List<StaffNamesVM>, List<StaffNames>>().ReverseMap();

            CreateMap<StaffNames, StaffNamesVM>().ReverseMap();


            //can write custom mapping otherwise its by convention
            //.ForMember(
            //      dest => dest.Id,
            //      opt => opt.MapFrom(src => src.Id)
            //  )
            //  .ForMember(
            //      dest => dest.Name,
            //      opt => opt.MapFrom(src => src.Name)
            //  )
            //  .ForMember(
            //      dest => dest.Department,
            //      opt => opt.MapFrom(src => src.Department)
            //  )

            //  .ForMember(
            //      dest => dest.VisitorCount,
            //      opt => opt.MapFrom(src => src.VisitorCount)
            //  )
            //  .ReverseMap();



        }

    }
}
