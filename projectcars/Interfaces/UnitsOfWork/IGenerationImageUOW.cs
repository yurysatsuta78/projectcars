using Microsoft.EntityFrameworkCore.Storage;
using projectcars.Interfaces.Repositories;

namespace projectcars.Interfaces.UnitsOfWork
{
    public interface IGenerationImageUOW
    {
        IGenerationsRepository Generations { get; }
        IImagesRepository Images { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveChangesAsync();
    }
}