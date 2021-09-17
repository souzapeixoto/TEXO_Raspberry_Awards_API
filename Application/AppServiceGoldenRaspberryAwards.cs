using Application.Interface;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class AppServiceGoldenRaspberryAwards : IAppServiceGoldenRaspberryAwards
    {
        private readonly IServiceGoldenRaspberryAwards _serviceGoldenRaspberryAwards;
        private readonly IRepositoryMovie _repositoryMovie;
        private readonly IRepositoryProducer _repositoryProducer;
        private readonly IRepositoryStudio _repositoryStudio;
        public AppServiceGoldenRaspberryAwards(IServiceGoldenRaspberryAwards serviceGoldenRaspberryAwards, IRepositoryStudio repositoryStudio, IRepositoryProducer repositoryProducer, IRepositoryMovie repositoryMovie)
        {
            _repositoryStudio = repositoryStudio;
            _repositoryProducer = repositoryProducer;
            _repositoryMovie = repositoryMovie;
            _serviceGoldenRaspberryAwards = serviceGoldenRaspberryAwards;
        }

        public void DeleteMovie(int id)
        {
            var movie = _repositoryMovie.GetById(id);
            _repositoryMovie.Delete(movie);
        }

        public ICollection<Movie> GetMovies()
        {
            return _repositoryMovie.GetAll().ToList();
        }

        public ICollection<Producer> GetProducers()
        {
            return _repositoryProducer.GetAll();
        }

        public DTOAwardsResponseGet GetProducerWithMaxIntervalAwardAndAwardsFast()
        {
            return _serviceGoldenRaspberryAwards.GetProducerWithMaxIntervalAwardAndAwardsFast();
        }

        public ICollection<Studio> GetStudios()
        {
            return _repositoryStudio.GetAll();
        }
    }
}
