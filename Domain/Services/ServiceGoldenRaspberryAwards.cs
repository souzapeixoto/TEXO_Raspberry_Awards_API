using CsvHelper;
using CsvHelper.Configuration;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Mapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Domain.Services
{
    public class ServiceGoldenRaspberryAwards : IServiceGoldenRaspberryAwards
    {
        private readonly IRepositoryProducer _repositoryProducer;
        public ServiceGoldenRaspberryAwards(IRepositoryMovie repositoryMovie, IRepositoryStudio repositoryStudio, IRepositoryProducer repositoryProducer)
        {
            _repositoryProducer = repositoryProducer;
        }
        public DTOAwardsResponseGet GetProducerWithMaxIntervalAwardAndAwardsFast()
        {
            var producers = _repositoryProducer.GetAll();
            DTOAwardsResponseGet response = null;
            var listIntervals = new List<IntervalAwards>();
            foreach (var p in producers)
            {
                var movies = p.Movies.Where(x => x.Winner).OrderByDescending(x => x.Year).Take(2).ToList();
                if(movies.Count > 0 && movies != null)
                {
                    var followingWin = movies.Max(x => x.Year);
                    var previousWin = movies.Min(x => x.Year);
                    var interval = (followingWin - previousWin);

                    if(interval > 0)
                        listIntervals.Add(new IntervalAwards { FollowingWin = followingWin, PreviousWin = previousWin, producer = p.Name, Interval = interval });
                }
                
            }

            var max = listIntervals.Where(x => x.Interval == listIntervals.Max(x => x.Interval));
            var min = listIntervals.Where(x => x.Interval == listIntervals.Min(x => x.Interval));

            response = new DTOAwardsResponseGet { Max = max.OrderByDescending(x => x.Interval).ToList(), Min = min.OrderBy(x => x.Interval).ToList() };
            return response;
        }

        
    }
}
