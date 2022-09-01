using AutoMapper;

using VisitorManagement.Models;

namespace VisitorManagement.Profiles
{
    public class AllClassesProfile : Profile
    {
        //load the mappings into the constructor
        public AllClassesProfile()
        {
            CreateMap<VisitorDTO, Visitor>();
            CreateMap<StaffNamesDTO, StaffNames>();
            //.ForMember(
            //      dest => dest.Id,
            //      opt => opt.MapFrom(src => $"{src.Id}")
            //  )
            //  .ForMember(
            //      dest => dest.Name,
            //      opt => opt.MapFrom(src => $"{src.Name}")
            //  )
            //  .ForMember(
            //      dest => dest.Department,
            //      opt => opt.MapFrom(src => $"{src.Department}")
            //  )

            //  .ForMember(
            //      dest => dest.VisitorCount,
            //      opt => opt.MapFrom(src => $"{src.VisitorCount}")
            //  );
        }

    }
}
