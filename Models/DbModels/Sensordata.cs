using System;

namespace ACDC2019SpiderpigsCovertOPs.Models.DbModels
{
    #pragma warning disable 1591
    public class Sensordata
    {
        public long Id { get; set; }
        public double Temprature { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}