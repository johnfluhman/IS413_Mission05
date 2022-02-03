using System;
using Microsoft.EntityFrameworkCore;

namespace Mission05.Models
{
    public class MovieSubmissionContext : DbContext
    {
        //Constructor 
        public MovieSubmissionContext (DbContextOptions<MovieSubmissionContext> options) : base (options)
        {
            
        }

        public DbSet<MovieSubmission> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(

                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Drama"
                },

                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Action"
                },

                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Thriller"
                },

                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Romance"
                },

                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Comedy"
                },

                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Horror"
                }
            );


            mb.Entity<MovieSubmission>().HasData(

                new MovieSubmission
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "Prisoners",
                    Year = 2013,
                    Director = "Denis Villeneuve",
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = "An amazing film"
                },

                new MovieSubmission
                {
                    MovieID = 2,
                    CategoryID = 1,
                    Title = "Sicario",
                    Year = 2015,
                    Director = "Denis Villeneuve",
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = "Another amazing film"
                },

                new MovieSubmission
                {
                    MovieID = 3,
                    CategoryID = 1,
                    Title = "Arrival",
                    Year = 2016,
                    Director = "Denis Villeneuve",
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = "An amazing alien film"
                }
            );
        }
    }
}
