using System;
using System.Collections.Generic;

namespace ACDC2019SpiderpigsCovertOPs.Models.DbModels
{
    #pragma warning disable 1591
    public class Spiderpig
    {
        public long Id { get; set; }
        public long BuildingId { get; set; }
        public bool Glasses { get; set; }
        public bool Friendly { get; set; }       
    }
}