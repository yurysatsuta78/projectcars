using Microsoft.EntityFrameworkCore.Storage;
using projectcars.Interfaces.Repositories;
using projectcars.Interfaces.UnitsOfWork;
using projectcars.Repositories;

namespace projectcars.UnitsOfWork
{
    public class GenerationImageUOW : IGenerationImageUOW
    {
        private readonly ApplicationDbContext _context;

        public GenerationImageUOW(ApplicationDbContext context)
        {
            _context = context;
            Generations = new GenerationsRepository(context);
            Images = new ImagesRepository(context);
        }

        public IGenerationsRepository Generations { get; }

        public IImagesRepository Images { get; }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CommitAsync()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.CommitAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.RollbackAsync();
            }
        }
    }
}
