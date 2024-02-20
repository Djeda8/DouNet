using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Controllers;
using MvcMovie.Data;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMoview.Tests.Controllers
{

    public class MoviesControllerTests
    {
        public MoviesControllerTests()
        {
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfMovieGenre()
        {
            // Arrange
            var db = SeedDatabase();
            var controller = new MoviesController(db);

            // Act
            var result = await controller.Index(null, null);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MovieGenreViewModel>(viewResult.ViewData.Model);
            Assert.Equal(4, model?.Movies?.Count);
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithMovieGenreAndSearchString()
        {
            // Arrange
            var db = SeedDatabase();
            var controller = new MoviesController(db);

            // Act
            var result = await controller.Index("Comedy", "2");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MovieGenreViewModel>(viewResult.ViewData.Model);
            Assert.Equal(1, model?.Movies?.Count);
        }

        [Fact]
        public async Task Index_ReturnProblem_withContextnull()
        {
            // Arrange
            var db = SeedDatabase();
            db.Movie = null;
            var controller = new MoviesController(db);

            // Act
            var result = await controller.Index(null, null);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
        }

        
        [Fact]
        public async Task Details_ReturnNotFound_withIdNull()
        {
            // Arrange
            var db = SeedDatabase();
            var controller = new MoviesController(db);

            // Act
            var result = await controller.Details(null);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Details_ReturnNotFound_withIdNotExits()
        {
            // Arrange
            var db = SeedDatabase();
            var controller = new MoviesController(db);

            // Act
            var result = await controller.Details(9999);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Details_ReturnModel_withIdCorrect()
        {
            // Arrange
            var db = SeedDatabase();
            var controller = new MoviesController(db);

            // Act
            var result = await controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Movie>(viewResult.ViewData.Model);
        }

        [Fact]
        public  void CreateGet_ReturnsView()
        {
            // Arrange
            var db = SeedDatabase();
            var controller = new MoviesController(db);

            // Act
            var result = controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        
        [Fact]
        public async Task CreatePost_ReturnsModel_WhenModelStateIsInvalid()
        {
            // Arrange
            var db = SeedDatabase();
            var controller = new MoviesController(db);
            controller.ModelState.AddModelError("Title", "Required");
            var newMovie = new Movie();
            
            // Act
            var result = await controller.Create(newMovie);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Movie>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task CreatePost_ReturnsARedirectAndAddsMovie_WhenModelStateIsValid()
        {
            // Arrange
            var db = SeedDatabase();
            var controller = new MoviesController(db);

            var newMovie = new Movie()
            {
                Title = "Dirty Dacing",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = "Comedy",
                Rating = "R",
                Price = 8.99M
            };

            // Act
            var result = await controller.Create(newMovie);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        private static MvcMovieContext SeedDatabase()
        {
            var db = new MvcMovieContext(new DbContextOptionsBuilder<MvcMovieContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

            db.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "R",
                    Price = 3.99M
                }
            );

            db.SaveChanges();

            return db;
        }
    }
}
