using CsvHelper.Configuration;
using Domain.DTOs;


namespace Domain.Mapper
{
    public sealed class MovieMap : ClassMap<MovieCSV>
    {
        public MovieMap()
        {
            Map(x => x.Year).Name("year");
            Map(x => x.Title).Name("title");
            Map(x => x.Studios).Name("studios");
            Map(x => x.Producers).Name("producers");
            Map(x => x.Winner).Name("winner");
        }
    }
}
