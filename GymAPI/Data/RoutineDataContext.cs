using GymAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.Data
{
    public class RoutineDataContext : DbContext
    {
        public RoutineDataContext(DbContextOptions<RoutineDataContext> options) : base(options) { 
        }
        public DbSet<Routine>? Routines { get; set; }
    }
}
