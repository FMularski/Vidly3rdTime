using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly3rdTime.Models.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreDTO Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public DateTime DateRealesed { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public int NumberInStock { get; set; }
    }
}