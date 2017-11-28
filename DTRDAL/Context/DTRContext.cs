using System;
using DTRDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DTRDAL.Context
{
    public class DTRContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DTRContext(DbContextOptions<DTRContext> options) : base(options)
        {
            //Ensure DB states
            //Comment deleted back in when updating DB
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define Student relation with Group
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(g => g.GroupId);
            
            modelBuilder.Entity<Project>()
                .HasOne(p => p.AssignedSupervisor)
                .WithMany(s => s.AssignedProjects)
                .HasForeignKey(s => s.AssignedSuporvisorId);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.WantedSupervisor)
                .WithMany(s => s.WantedProjects)
                .HasForeignKey(s => s.WantedSuporvisorId);

            // Define contract primary key
            modelBuilder.Entity<Contract>()
                .HasKey(c => new {c.GroupId, c.CompanyId, c.ProjectId});
        }
    }
}