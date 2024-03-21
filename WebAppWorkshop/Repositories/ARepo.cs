using Microsoft.EntityFrameworkCore;
using WebAppWorkshop.DAL;
using WebAppWorkshop.Models;

namespace WebAppWorkshop.Repositories
{
    public class ARepo : IRepository<Appointment>
    {
        private readonly GeneralDbContext _generalDbContext;
        public ARepo(GeneralDbContext generalDb )
        {
            _generalDbContext = generalDb;
        }
        public async Task AddAsync(Appointment entity)
        {
            await _generalDbContext.appointments.AddAsync(entity);
            await _generalDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var c2dl = await _generalDbContext.appointments.FindAsync(id);
            if (c2dl != null) {
                _generalDbContext.appointments.Remove(c2dl);
                await _generalDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
           return await _generalDbContext.appointments.Include(t => t.receptionist).Include(t => t.visitorID).ToArrayAsync();
        }

        public async Task<Appointment> GetByIDAsync(int id)
        {
            return await _generalDbContext.appointments.FindAsync(id);
        }

        public async Task UpdateAsync(Appointment entity)
        {
            _generalDbContext.Entry(entity).State = EntityState.Modified;
            await _generalDbContext.SaveChangesAsync();
        }
    }
}
