using Microsoft.EntityFrameworkCore;
using WebAppWorkshop.DAL;
using WebAppWorkshop.Models;

namespace WebAppWorkshop.Repositories
{
    public class RRepo : IRepository<Receptionist>
    {
        private readonly GeneralDbContext _context;
        public RRepo(GeneralDbContext context)
        {
            _context = context; 
        }
        public async Task AddAsync(Receptionist entity)
        {
            await _context.receptionists.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var a2dl = await _context.receptionists.FindAsync(id);
            if (a2dl != null)
            {
                _context.receptionists.Remove(a2dl);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Receptionist>> GetAllAsync()
        {
            return await _context.receptionists.ToArrayAsync();
        }

        public async Task<Receptionist> GetByIDAsync(int id)
        {
            return await _context.receptionists.FirstOrDefaultAsync(t => t.id == id);
        }

        public async Task UpdateAsync(Receptionist entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
