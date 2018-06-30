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
                new Customer { Name = "John Smith", IsSubscribedToNewsletter = false, MembershipTypeId = 1 },
                new Customer { Name = "Mary Williams", IsSubscribedToNewsletter = true, MembershipTypeId = 2 }
            );
        }
    }
}
