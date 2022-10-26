using GymAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.Data
{
    public class ExerciseDataContext : DbContext
    {
        public ExerciseDataContext(DbContextOptions<ExerciseDataContext> options) : base(options) { }

        public DbSet<Exercise>? Exercises { get; set; }
    }

}
