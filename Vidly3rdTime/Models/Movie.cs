﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly3rdTime.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public DateTime DateRealesed { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}