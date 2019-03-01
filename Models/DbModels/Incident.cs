using System;

namespace ACDC2019SpiderpigsCovertOPs.Models.DbModels
{
    #pragma warning disable 1591
    public class Incident
    {
        public long Id { get; set; }
        public double Temperature { get; set; }
        public string Responsible { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }        
    }
}