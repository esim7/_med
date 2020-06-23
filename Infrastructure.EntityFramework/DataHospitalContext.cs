using System;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class DataHospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<VisitHistory> VisitHistories { get; set; }

        public DataHospitalContext(DbContextOptions<DataHospitalContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
