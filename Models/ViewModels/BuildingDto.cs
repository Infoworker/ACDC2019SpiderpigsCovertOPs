namespace ACDC2019SpiderpigsCovertOPs.Models.ViewModels
{
    #pragma warning disable 1591
    public class BuildingDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Feed { get; set; }
        public PositionDto Position { get; set; }  
    }
}