using CsvHelper;
using CsvHelper.Configuration;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Mapper;
using Infrastructure.CrossCutting.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seed
{
    public class Initializer
    {
        public static async Task SeedData(IServiceProvider serviceProvider, string path)
        {
            var _service = (IServiceGoldenRaspberryAwards)serviceProvider.GetService(typeof(IServiceGoldenRaspberryAwards));
            var _repositoryStudio = (IRepositoryStudio)serviceProvider.GetService(typeof(IRepositoryStudio));
            var _repositoryProducer = (IRepositoryProducer)serviceProvider.GetService(typeof(IRepositoryProducer));
            var _repositoryMovie = (IRepositoryMovie)serviceProvider.GetService(typeof(IRepositoryMovie));
            var _unitOfWork = (IUnitOfWork)serviceProvider.GetService(typeof(IUnitOfWork));
            _unitOfWork.Commit();
            //List<UserModel> users = new List<UserModel>();
            var fileName = path;

            try
            {
                using (var reader = new StreamReader(fileName, System.Text.Encoding.UTF8))
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ";",
                        
                    };
                    using (var csv = new CsvReader(reader, config))
                    {

                        csv.Context.RegisterClassMap<MovieMap>();

                        var movieList = csv.GetRecords<MovieCSV>().ToList();
                        string[] stringSeparators = new string[] { ",", " and " };


                        foreach (var m in movieList)
                        {
                            var movie = new Movie()
                            {
                                Title = m.Title,
                                Winner = m.Winner.ToLower() == "yes" ? true : false,
                                Year = m.Year
                            };
                            var studiosList = m.Studios.Split(stringSeparators, StringSplitOptions.None);
                            var producersList = m.Producers.Split(stringSeparators, StringSplitOptions.None);

                            foreach (var s in studiosList)
                            {
                                var studio = _repositoryStudio.GetByName(s.Trim());
                                if (studio != null)
                                {
                                    movie.Studios.Add(studio);
                                }
                                else if (s != "")
                                {
                                    movie.Studios.Add(new Studio { Name = s.Trim() });
                                }
                            }
                            foreach (var p in producersList)
                            {
                                var producer = _repositoryProducer.GetByName(p.Trim());
                                if (producer != null)
                                {
                                    movie.Producers.Add(producer);
                                }
                                else if (p != "")
                                {
                                    movie.Producers.Add(new Producer { Name = p.Trim() });
                                }

                            }

                            _repositoryMovie.Insert(movie);
                            _unitOfWork.Commit();
                        }
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


    }
}
