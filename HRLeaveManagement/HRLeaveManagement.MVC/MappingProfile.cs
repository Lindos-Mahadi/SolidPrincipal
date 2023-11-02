using AutoMapper;
using HR.LeaveManagement.MVC.Services.Base;
using HRLeaveManagement.MVC.Models;

namespace HRLeaveManagement.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        }
    }
}
