using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.DTOs
{
    public class DTOProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<DTOMovie> Movies { get; set; }
    }
}
