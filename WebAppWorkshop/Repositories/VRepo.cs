using Microsoft.EntityFrameworkCore;
using WebAppWorkshop.DAL;
using WebAppWorkshop.Models;

namespace WebAppWorkshop.Repositories
{
    public class VRepo : IRepository<Visitor>
    {
        private readonly GeneralDbContext _context;
        public VRepo(GeneralDbContext context)
        {
            _context = context; 
        }
        public async Task AddAsync(Visitor entity)
        {
            await _context.visitors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var a2dl = await _context.visitors.FindAsync(id);
            if (a2dl != null)
            {
                _context.visitors.Remove(a2dl);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Visitor>> GetAllAsync()
        {
            return await _context.visitors.ToArrayAsync();
        }

        public async Task<Visitor> GetByIDAsync(int id)
        {
            return await _context.visitors.FirstOrDefaultAsync(t => t.id == id);
        }

        public async Task UpdateAsync(Visitor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
