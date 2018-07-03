using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly3rdTime.Models;

namespace Vidly3rdTime.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; } // int? type is not necessary here

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Realese date is required.")]
        public DateTime? DateReleased { get; set; }

        [Required(ErrorMessage = "Genre is requied.")]
        public int? GenreId { get; set; }

        [Required(ErrorMessage = "Number in stock value is required.")]
        [Range(1, 20, ErrorMessage = "Number in Stock value has to be between 1 and 20.")]
        public int? NumberInStock { get; set; }

        public MovieFormViewModel()
        {
            Id = 0; // if new movie is being added its id should be 0, 
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            DateReleased = movie.DateRealesed;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }


        public string Title
        {
            get
            {
                if ( Id != 0)
                    return "Edit Movie";
                
                return "New Movie";
            }
        }
    }
}