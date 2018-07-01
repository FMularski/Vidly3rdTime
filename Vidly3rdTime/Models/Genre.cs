using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly3rdTime.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}