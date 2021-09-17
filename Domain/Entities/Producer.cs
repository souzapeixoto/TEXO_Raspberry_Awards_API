using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.Entities
{

    public class Producer
    {
        public Producer()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
