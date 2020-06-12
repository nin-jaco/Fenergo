using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using AutoMapper;
using Fenergo.Ui.Dtos;
using Fenergo.Ui.Models;

namespace Fenergo.Ui.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //domain to dto
            Mapper.CreateMap<Hardware, HardwareDto>();
            Mapper.CreateMap<Photo, PhotoDto>();
            Mapper.CreateMap<HardwareType, HardwareTypeDto>();

            //dto to domain
            Mapper.CreateMap<HardwareDto, Hardware>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<PhotoDto, Photo>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<HardwareTypeDto, HardwareType>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}