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
        //public Testcontext(DbContextOptions<Testcontext> options):base(options) 
        //{

        //}
    }
}
