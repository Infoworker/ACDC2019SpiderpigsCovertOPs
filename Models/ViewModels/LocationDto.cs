using System;

namespace ACDC2019SpiderpigsCovertOPs.Models.ViewModels
{
    #pragma warning disable 1591
    public class LocationDto
    {
        public long Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public DateTime Time { get; set; }
        public PersonDto Person { get; set; }
    }
}