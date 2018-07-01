﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly3rdTime.Models;

namespace Vidly3rdTime.EntitiesConfigurations
{
    public class MembershipTypeConfiguration : EntityTypeConfiguration<MembershipType>
    {
        public MembershipTypeConfiguration()
        {
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}