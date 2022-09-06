using AutoMapper;
using VisitorManagement.Models;
using VisitorManagement.ViewModels;

namespace VisitorManagement.Profiles
{
    public class AutoMapperProfile : Profile
    {
        //put maps in the constructor
        public AutoMapperProfile()
        {
            CreateMap<Visitor, VisitorVM>().ReverseMap();
            CreateMap<StaffNames, StaffNamesVM>().ReverseMap();
        }
    }
}
