using System.Collections.Generic;

namespace ACDC2019SpiderpigsCovertOPs.Models.ViewModels
{
    #pragma warning disable 1591
    public class PersonInsertDto
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<LocationInsertDto> Location { get; set; }
    }
}