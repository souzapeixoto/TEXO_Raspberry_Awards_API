using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Mapper
{
    public class StudioProfile : Profile
    {
        public StudioProfile()
        {
            CreateMap<Studio, DTOStudio>().ReverseMap();
        }
    }
}
