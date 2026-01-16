using _01_07_2025_tutorial_razor_pages.Models;
using Microsoft.EntityFrameworkCore;
using _01_07_2025_tutorial_razor_pages.Data;

namespace RazorPagesMovie.Models;
// Note instances of "RazorPagesMovieContext" replaced with "_01_07_2025_tutorial_razor_pagesContext"

// Note when Rating was added as a new property to the Movie model, the database had to be updated via a new migration:
//      Tools > NuGet Package Manager > Package Manager Console
//      Add-Migration Rating
//      Update-Database

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new _01_07_2025_tutorial_razor_pagesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<_01_07_2025_tutorial_razor_pagesContext>>()))
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R"
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "G"
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "G"
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "NA"
                }
            );
            context.SaveChanges();
        }
    }
}