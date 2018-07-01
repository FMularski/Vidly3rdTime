namespace Vidly3rdTime.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vidly3rdTime.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Vidly3rdTime.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vidly3rdTime.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Customers.AddOrUpdate(c => c.Name,
                new Customer { Name = "John Smith", IsSubscribedToNewsletter = false, MembershipTypeId = 1, Birthdate = new DateTime(1980, 1, 1) },
                new Customer { Name = "Mary Williams", IsSubscribedToNewsletter = true, MembershipTypeId = 2 }
            );

            context.Movies.AddOrUpdate(m => m.Name,

                new Movie { Name = "Hangover", GenreId = 1 , DateRealesed = new DateTime( 2009, 11, 6), DateAdded = new DateTime( 2016, 5, 4), NumberInStock = 5 },
                new Movie { Name = "Die Hard", GenreId = 2 , DateRealesed = new DateTime( 2008, 9, 12), DateAdded = new DateTime( 2016, 5, 4), NumberInStock = 4 },
                new Movie { Name = "The Terminator", GenreId = 2 , DateRealesed = new DateTime( 2010, 3, 20), DateAdded = new DateTime( 2016, 8, 19), NumberInStock = 6 },
                new Movie { Name = "Toy Story", GenreId = 3 , DateRealesed = new DateTime( 2001, 12, 1), DateAdded = new DateTime( 2016, 4, 9), NumberInStock = 9 },
                new Movie { Name = "Titanic", GenreId = 4 , DateRealesed = new DateTime( 2000, 7, 11), DateAdded = new DateTime( 2016, 10, 2), NumberInStock = 6}
                );
        }
    }
}
