using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.DTOs
{
    public class DTOMovie
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public  ICollection<DTOStudio> Studios { get; set; }
        [JsonIgnore]
        public  ICollection<DTOProducer> Producers { get; set; }
        public bool Winner { get; set; }
    }
}
