namespace projectcars.Models
{
    public class Region
    {
        private Region(Guid regionId, string regionName) 
        {
            RegionId = regionId;
            RegionName = regionName;
        }

        public static Region Create(Guid regionId, string regionName) 
        {
            return new Region(regionId, regionName);
        }

        public Guid RegionId { get; set; }
        public string RegionName { get; set; }
    }
}
