using Application.Interface;
using AutoMapper;
using Domain.DTOs;
using Infrastructure.CrossCutting.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TEXO_Raspberry_Awards_API.Controllers
{
    [Route("api/GoldenRaspberryAwards")]
    public class GoldenRaspberryAwardsController : Controller
    {
        private readonly IMapper _map;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GoldenRaspberryAwardsController> _logger;
        private readonly IAppServiceGoldenRaspberryAwards _appServiceGoldenRaspberryAwards;
        public GoldenRaspberryAwardsController(ILogger<GoldenRaspberryAwardsController> logger, IUnitOfWork unitOfWork, IMapper map, IAppServiceGoldenRaspberryAwards appServiceGoldenRaspberryAwards)
        {
            _unitOfWork = unitOfWork;
            _map = map;
            _logger = logger;
            _appServiceGoldenRaspberryAwards = appServiceGoldenRaspberryAwards;
        }
        /// <summary>
        /// Obtem o produtor com maior intervalo entre dois prêmios consecutivos, e o que
        /// obteve dois prêmios mais rápido
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                // var response = _appServiceGoldenRaspberryAwards.GetProducerWithMaxIntervalAwardAndAwardsFast();
                return Ok(_appServiceGoldenRaspberryAwards.GetProducerWithMaxIntervalAwardAndAwardsFast());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(null);

            }
        }
        /// <summary>
        /// Exlui um filme da lista de acordo com o ID passado
        /// </summary>
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _appServiceGoldenRaspberryAwards.DeleteMovie(id);
                _unitOfWork.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(null);

            }
        }
        /// <summary>
        /// Lista todos os produtores
        /// </summary>
        [HttpGet]
        [Route("Producers")]
        public async Task<ActionResult> Producers()
        {
            try
            {
                ICollection<DTOProducer> producers =
                _map.Map<List<DTOProducer>>(_appServiceGoldenRaspberryAwards.GetProducers());
                //var response = _appServiceGoldenRaspberryAwards.GetProducers().Select(x=>x.Name).OrderBy(x=>x);
                // var response = _appServiceGoldenRaspberryAwards.GetProducerWithMaxIntervalAwardAndAwardsFast();
                return Ok(JsonConvert.SerializeObject(producers, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(null);

            }
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        [HttpGet]
        [Route("Movies")]
        public async Task<ActionResult> Movies()
        {
            try
            {
                ICollection<DTOMovie> movies =
                _map.Map<List<DTOMovie>>(_appServiceGoldenRaspberryAwards.GetMovies());
                // var response = _appServiceGoldenRaspberryAwards.GetProducerWithMaxIntervalAwardAndAwardsFast();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(null);

            }
        }
        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        [HttpGet]
        [Route("Studios")]
        public async Task<ActionResult> Studios()
        {
            try
            {
                ICollection<DTOStudio> studios =
                _map.Map<List<DTOStudio>>(_appServiceGoldenRaspberryAwards.GetStudios());
                // var response = _appServiceGoldenRaspberryAwards.GetProducerWithMaxIntervalAwardAndAwardsFast();
                return Ok(studios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(null);

            }
        }

    }
}
