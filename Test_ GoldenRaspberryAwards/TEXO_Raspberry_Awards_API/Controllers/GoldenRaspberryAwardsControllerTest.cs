
using Application;
using Application.Interface;
using Domain.DTOs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infrastructure.CrossCutting.UnitOfWork;
using Infrastructure.CrossCutting.UnitOfWork.Interface;
using Infrastructure.Data;
using Infrastructure.Data.Seed;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TEXO_Raspberry_Awards_API;
using Xunit;

namespace Test__GoldenRaspberryAwards.TEXO_Raspberry_Awards_API.Controllers
{

    public class GoldenRaspberryAwardsControllerTest
    {
        public static IServiceProvider _serviceProvider { get; set; }
        private readonly HttpClient _client;
        private readonly string endpoint = "/api/GoldenRaspberryAwards/";
        public GoldenRaspberryAwardsControllerTest()
        {
            var environment = "Development";
            var directory = Directory.GetCurrentDirectory();
            ServiceCollection sc = new ServiceCollection();
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json");
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment(environment)
                .UseConfiguration(configurationBuilder.Build())
                .ConfigureServices(services =>
                {
                    services.AddScoped<IRepositoryMovie, RepositoryMovie>();
                    services.AddScoped<IRepositoryStudio, RepositoryStudio>();
                    services.AddScoped<IRepositoryProducer, RepositoryProducer>();
                    services.AddScoped<IUnitOfWork, UnitOfWork>();
                    services.AddScoped<IAppServiceGoldenRaspberryAwards, AppServiceGoldenRaspberryAwards>();
                    services.AddScoped<IServiceGoldenRaspberryAwards, ServiceGoldenRaspberryAwards>();
                })
                .UseStartup<Startup>());
               
            _client = server.CreateClient();
            

            _ = Initializer.SeedData(server.Services, @"../../../../Domain/FileSeed/movielist.csv");
        }

        [Theory]
        [InlineData("GET")]
        public async Task Get(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), endpoint);
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET")]
        public async Task GetMovies(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), endpoint+"movies");
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET")]
        public async Task GetProducers(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), endpoint + "producers");
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET")]
        public async Task GetStudios(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), endpoint + "studios");
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("DELETE",1)]
        public async Task Delete(string method,int id)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), endpoint + id);
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}
