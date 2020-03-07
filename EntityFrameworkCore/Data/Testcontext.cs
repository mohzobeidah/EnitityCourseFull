using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    public class Testcontext:DbContext
    {
       public DbSet<Student> students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Teacher_Course> Teachers_Courses { get; set; }
        public DbSet<TwoPrimaryKey> twoPrimaryKeys { get; set; }
        // SHow Views Is Faster than Table   
        public DbQuery<TeacherView> teacherViews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "CoreTest",
                IntegratedSecurity = true


            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ToString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TwoPrimaryKey>().HasKey(x => new { x.id1, x.id2 });// composite Primary key
            modelBuilder.Entity<TwoPrimaryKey>().Property<string>("ShadowProperty");

            modelBuilder.Entity<Teacher_Course>().HasIndex(x => x.Hours);
            //هذا السطر يقدر يخزن البيانات بشكل مشفر مثل وارجاعها بشكل اخر غير مشفر 
            //modelBuilder.Entity<Teachers>().Property(x => x.Name).HasConversion(W => W.ToJson(), R => R.FromJson<string>());
            base.OnModelCreating(modelBuilder);
        }
        //public Testcontext(DbContextOptions<Testcontext> options):base(options) 
        //{

        //}
    }
    public class TeacherView {
        public string name { get; set; }


    }



}
