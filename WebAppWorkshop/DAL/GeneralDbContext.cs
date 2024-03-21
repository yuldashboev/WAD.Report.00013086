using Microsoft.EntityFrameworkCore;
using WebAppWorkshop.Models;

namespace WebAppWorkshop.DAL
{
    public class GeneralDbContext : DbContext
    {
        public GeneralDbContext(DbContextOptions<GeneralDbContext> o) : base(o) { }
        public DbSet<Receptionist> receptionists { get; set; }
        public DbSet<Visitor> visitors { get; set; }
        public DbSet<Appointment> appointments { get; set; }
    }
}
