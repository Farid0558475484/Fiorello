using System;
using FiorelloProject.Models;
using FiorelloProject.Models.Demo;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using FiorelloProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FiorelloProject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Student> Students { get; set; }
        public DbSet<Slider>? Sliders { get; set; }
        public DbSet<SliderDetail>? SliderDetails { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductImage>? ProductImages { get; set; }
        public DbSet<Bio>? Bios { get; set; }



        ///Demooo-----
        public DbSet<Book>? Book { get; set; }
        public DbSet<BookImages>? BookImages { get; set; }
        public DbSet<BookGenre>? BookGenres { get; set; }
        public DbSet<BookAuthor>? BookAuthors { get; set; }
        public DbSet<SosialPage>? SosialPages { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public object Books { get; internal set; }

        internal object Include()
        {
            throw new NotImplementedException();
        }
    }
}

