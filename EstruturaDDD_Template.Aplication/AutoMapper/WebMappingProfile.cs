using AutoMapper;
using TrocoBrq.Cross.DTO;
using TrocoBrq.Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrocoBrq.Aplication.AutoMapper
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {

            CreateMap<RetornoDTO, RetornoViewModel>()
                .ReverseMap();

            CreateMap<MoedaDTO, MoedaViewModel>()
                .ReverseMap();
                //.ForMember(dto => dto.CreatedAt, opt => opt.Ignore());
        }
    }
}
