namespace ACDC2019SpiderpigsCovertOPs.Models.DbModels
{
    #pragma warning disable 1591
    public class Building
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Feed { get; set; }
        public Position Position { get; set; }  
    }
}