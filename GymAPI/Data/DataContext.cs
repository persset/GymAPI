
using GymAPI.Migrations;
using GymAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserType> UserTypes => Set<UserType>();
        public DbSet<UserPrivilege> UserPrivileges => Set<UserPrivilege>();
        public DbSet<User> Users => Set<User>();
        public DbSet<PlanPeriodicity> PlanPeriodicities => Set<PlanPeriodicity>();
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<MuscleGroup> MuscleGroups => Set<MuscleGroup>();
        public DbSet<Exercise> Exercises => Set<Exercise>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Functionary> Functionaries => Set<Functionary>();
        public DbSet<Training> Trainings => Set<Training>();
        public DbSet<TrainingOrganization> TrainingsOrganizations => Set<TrainingOrganization>();
    }

}
