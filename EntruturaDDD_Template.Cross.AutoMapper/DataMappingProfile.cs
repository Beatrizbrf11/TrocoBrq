using AutoMapper;
using TrocoBrq.Cross.DTO;
using TrocoBrq.Domain.Entities;
using System;

namespace TrocoBrq.Cross.AutoMapper
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Moeda, MoedaDTO>().ReverseMap()
                .ForMember(dto => dto.CriadoPor, opt => opt.Ignore())
                .ForMember(dto => dto.DataCriadao, opt => opt.Ignore())
                .ForMember(dto => dto.Quantidade, opt => opt.Ignore());
            
        }  
    }
}
