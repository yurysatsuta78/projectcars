namespace projectcars.Entities
{
    public class RegionEntity
    {
        public Guid RegionId { get; set; }
        public string? RegionName { get; set; }
        public ICollection<CityEntity>? CityEntities { get; }
    }
}
