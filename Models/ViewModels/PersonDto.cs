using System;
using System.Collections.Generic;

namespace ACDC2019SpiderpigsCovertOPs.Models.ViewModels
{
    #pragma warning disable 1591
    public class PersonDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Icon { get; set; }
        public DateTime Age { get; set; }
        // public Building Home { get; set; }
        // public Building Work { get; set; }
        public string FavoriteDrink { get; set; }
        public string FavoriteFood { get; set; }
        public string Quote { get; set; }
        public List<LocationDto> Location { get; set; }
    }
}