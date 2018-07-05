using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly3rdTime.Models;

namespace Vidly3rdTime.EntitiesConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(u => u.DrivingLicense)
                .IsRequired()
                .HasMaxLength(255);

            Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}