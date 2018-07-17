using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly3rdTime.Models;

namespace Vidly3rdTime.EntitiesConfigurations
{
    public class RentalConfiguration : EntityTypeConfiguration<Rental>
    {
        public RentalConfiguration()
        {
            HasRequired(r => r.Customer)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CustomerId);

            HasRequired(r => r.Movie)
                .WithMany(m => m.Rentals)
                .HasForeignKey(r => r.MovieId);
        }
    }
}