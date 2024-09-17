using Microsoft.EntityFrameworkCore.Storage;
using projectcars.Interfaces.Repositories;
using projectcars.Interfaces.UnitsOfWork;
using projectcars.Repositories;

namespace projectcars.UnitsOfWork
{
    public class BrandImageUOW : IBrandImageUOW
    {
        private readonly ApplicationDbContext _context;

        public BrandImageUOW(ApplicationDbContext context)
        {
            _context = context;
            Brands = new BrandsRepository(context);
            Images = new ImagesRepository(context);
        }

        public IBrandsRepository Brands { get; }

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
            if(_context.Database.CurrentTransaction != null) 
            {
                await _context.Database.CurrentTransaction.CommitAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if(_context.Database.CurrentTransaction != null) 
            {
                await _context.Database.CurrentTransaction.RollbackAsync();
            }
        }
    }
}
