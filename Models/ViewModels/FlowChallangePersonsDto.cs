using System;

namespace ACDC2019SpiderpigsCovertOPs.Models.ViewModels
{
    public class FlowChallangePersonsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Relation { get; set; }
        public string Role { get; set; }
    }
}