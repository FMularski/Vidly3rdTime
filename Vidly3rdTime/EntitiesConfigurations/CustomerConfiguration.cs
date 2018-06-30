using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly3rdTime.Models;

namespace Vidly3rdTime.EntitiesConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(c => c.MembershipType)
                .WithMany(m => m.Customers)
                .HasForeignKey(c => c.MembershipTypeId);
        } 
    }
}