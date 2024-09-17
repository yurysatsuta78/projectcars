using Microsoft.EntityFrameworkCore.Storage;
using projectcars.Interfaces.Repositories;

namespace projectcars.Interfaces.UnitsOfWork
{
    public interface IBrandImageUOW
    {
        IBrandsRepository Brands { get; }
        IImagesRepository Images { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveChangesAsync();
    }
}