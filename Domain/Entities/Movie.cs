using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Movie
    {
        public Movie()
        {
            this.Studios = new HashSet<Studio>();
            this.Producers = new HashSet<Producer>();
        }
        public int Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Studio> Studios { get; set; }
        public virtual ICollection<Producer> Producers{ get; set; }
        public bool Winner { get; set; }

    }
}
