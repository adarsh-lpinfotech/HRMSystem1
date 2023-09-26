using AutoMapper;
using HRMSystem_DataAccess;
using HRMSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSystem_Business.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Department,DepartmentDto>().ReverseMap();
        }
    }
}
