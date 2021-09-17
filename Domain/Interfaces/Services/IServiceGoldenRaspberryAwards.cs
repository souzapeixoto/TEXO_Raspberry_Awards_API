using Domain.DTOs;

namespace Domain.Interfaces.Services
{
    public interface IServiceGoldenRaspberryAwards
    {
        public DTOAwardsResponseGet GetProducerWithMaxIntervalAwardAndAwardsFast();
    }
}
