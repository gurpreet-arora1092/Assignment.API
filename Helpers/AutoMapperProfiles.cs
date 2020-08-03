using System;
using Assignment.API.Models;
using Assignment.API.ViewModels;
using AutoMapper;

namespace Assignment.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeForListDto>();
            CreateMap<EmployeeForRegisterDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
        }

    }
}
