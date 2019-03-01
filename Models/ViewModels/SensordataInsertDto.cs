using System;

namespace ACDC2019SpiderpigsCovertOPs.Models.ViewModels
{
    #pragma warning disable 1591
    public class SensordataInsertDto
    {
        public double Temprature { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}