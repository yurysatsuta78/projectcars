namespace projectcars.DTO.Car
{
    public class CarModelDTO
    {
        public string ModelName { get; set; } = string.Empty;
        public CarBrandDTO? Brand { get; set; }
    }
}
