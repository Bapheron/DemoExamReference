using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReference.Models
{
    public class TestDBConext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.JobDuties> JobDuties { get; set; }
        public DbSet<Models.Builder> Builders { get; set; }
        public DbSet<Models.BuilderJobDuties> BuilderJobDuties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\Local;Initial Catalog=DemoDbRef;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Models.User>().HasData
            (
                new User
                {
                    Id = 1,
                    Login = "admin",
                    Password = "1",
                    Role = Enums.UserRole.administrator
                }
            );

            modelBuilder.Entity<Builder>().HasData
            (
                new Builder
                {
                    Id = 1,
                    FirstName = "Jhon",
                    SecondName = "Jhons",
                    Patronymic = "Jhonson"
                }
            );

            modelBuilder.Entity<JobDuties>().HasData
            (
                new JobDuties
                {
                    Id = 1,
                    Name = "job 1",
                    Description = "job 1 desc"
                }
            );

            modelBuilder.Entity<BuilderJobDuties>().HasData
            (
                new BuilderJobDuties
                {
                    Id = 1,
                    BuilderId = 1,
                    JobDutiesId = 1,
                    UserId = 1
                }
            );

        }
    }
}
