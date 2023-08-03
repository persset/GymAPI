﻿
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
    }

}
