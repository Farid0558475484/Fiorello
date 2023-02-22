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
        public DbSet<SliderDetail> SliderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }


    }
}

