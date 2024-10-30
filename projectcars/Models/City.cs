namespace projectcars.Models
{
    public class City
    {
        private City(Guid cityId, string cityName, Guid regionId) 
        {
            CityId = cityId;
            CityName = cityName;
            RegionId = regionId;
        }

        public static City Create(Guid cityId, string cityName, Guid regionId) 
        {
            return new City(cityId, cityName, regionId);
        }

        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public Guid RegionId { get; set; }
    }
}
