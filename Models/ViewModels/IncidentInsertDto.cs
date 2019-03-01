using System;

namespace ACDC2019SpiderpigsCovertOPs.Models.ViewModels
{
    #pragma warning disable 1591
    public class IncidentInsertDto
    {        
        public double Temperature { get; set; }
        public string Responsible { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }  
    }
}