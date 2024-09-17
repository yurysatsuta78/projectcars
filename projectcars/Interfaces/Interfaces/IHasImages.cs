using projectcars.Entities;

namespace projectcars.Interfaces.Interfaces
{
    public interface IHasImages
    {
        ICollection<ImageEntity>? ImageEntities { get; }
    }
}
