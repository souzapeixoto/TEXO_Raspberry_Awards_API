using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Mapper
{
    public class ProducerProfile : Profile
    {
        public ProducerProfile()
        {
            CreateMap<Producer, DTOProducer>().ReverseMap();
        }
    }
}
