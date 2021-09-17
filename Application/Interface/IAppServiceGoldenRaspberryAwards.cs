using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interface
{
    public interface IAppServiceGoldenRaspberryAwards
    {
        public DTOAwardsResponseGet GetProducerWithMaxIntervalAwardAndAwardsFast();
        public ICollection<Movie> GetMovies();
        public ICollection<Producer> GetProducers();
        public ICollection<Studio> GetStudios();
        public void DeleteMovie(int id);
    }
}
