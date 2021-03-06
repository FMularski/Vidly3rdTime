﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly3rdTime.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}