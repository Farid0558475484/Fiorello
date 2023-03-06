using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorelloProject.DAL;
using FiorelloProject.Extensions;
using FiorelloProject.Models.Demo;
using FiorelloProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FiorelloProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class DemoController : Controller
    {


        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public DemoController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(_appDbContext.Authors.ToList(),"Id","Name");
            ViewBag.Genres = new SelectList(_appDbContext.Genres.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]

        public IActionResult Create(BookCreateVM bookCreateVM)
        {
            ViewBag.Authors = new SelectList(_appDbContext.Authors.ToList(), "Id", "Name");
            ViewBag.Genres = new SelectList(_appDbContext.Genres.ToList(), "Id", "Name");


            List<BookImages> bookImages = new();
            foreach (var photo in bookCreateVM.Photos)
            {



                if (!photo.IsImage())
                {
                    ModelState.AddModelError("Photos", "Ancag Sekil");
                    return View();
                }


                if (photo.CheckImageSize(500))
                {
                    ModelState.AddModelError("Photos", "Olcu Boyukdu");
                    return View();
                }


                BookImages bookImage = new();
                bookImage.ImageUrl = photo.SaveImage(_env, "img", photo.FileName);
                bookImages.Add(bookImage);
            }


            List<BookGenre> bookGenres = new();
            List<BookAuthor> bookAuthors = new();
            Book newBook = new();
            foreach (var item in bookCreateVM.GenreIds)
            {
                BookGenre bookGenre = new();
                bookGenre.BookId = newBook.Id;
                bookGenre.GenreId = item;
                bookGenres.Add(bookGenre);

            }


            foreach (var item in bookCreateVM.AuthorIds)
            {
                BookAuthor bookAuthor = new();
                bookAuthor.BookId = newBook.Id;
                bookAuthor.AuthorId = item;
                bookAuthors.Add(bookAuthor);

            }



            //Book newBook = new();
            newBook.Name = bookCreateVM.Name;
            newBook.BookGenres= bookGenres;
            newBook.BookAuthors=bookAuthors;
            newBook.BookImages = bookImages;


            _appDbContext.Book.Add(newBook);
            _appDbContext.SaveChanges();


            return View();
        }
    }
}