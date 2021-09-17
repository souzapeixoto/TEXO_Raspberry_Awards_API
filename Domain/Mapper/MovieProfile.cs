using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Mapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, DTOMovie>().ReverseMap();
        }
    }
}
