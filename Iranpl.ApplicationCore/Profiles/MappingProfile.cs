using AutoMapper;
using Iranpl.Domain.Dto.Login;
using Iranpl.Domain.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginDto, LoginViewModel>().ReverseMap();
        }
    }
}
