using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain;

namespace StudentManagement.Repo
{
    public class EfContext : DbContext
    {
        public EfContext() : base() { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<StudentSubject> StudentSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=studentsubject;user=root;password=12345;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id); // Ensure the primary key is set
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Age).IsRequired();
            entity.Property(e => e.Address).IsRequired();

        
        });
}
    }
}
