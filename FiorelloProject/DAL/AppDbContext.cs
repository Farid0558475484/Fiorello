using System;
using FiorelloProject.Models;
//using FiorelloProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FiorelloProject.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Student> Students { get; set; }
        public DbSet<Slider> Sliders { get; set; }


    }
}

