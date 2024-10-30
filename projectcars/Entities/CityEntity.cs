namespace projectcars.Entities
{
    public class CityEntity
    {
        public Guid CityId { get; set; }
        public string? CityName { get; set; }
        public RegionEntity? RegionEntity { get; }
        public Guid RegionId { get; set; }
        public ICollection<CarEntity>? CarEntities { get; }
    }
}
