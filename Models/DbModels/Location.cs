using System;

namespace ACDC2019SpiderpigsCovertOPs.Models.DbModels
{
    #pragma warning disable 1591
    public class Location
    {
        public long Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public DateTime Time { get; set; }
        public Person Person { get; set; }
    }
}