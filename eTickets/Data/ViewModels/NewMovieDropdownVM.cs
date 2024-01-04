using eTickets.Models;
using System.Collections.Generic;

namespace eTickets.Data.ViewModels
{
    public class NewMovieDropdownVM
    {
        public NewMovieDropdownVM()
        {
            Actors = new List<Actor>();
            Cinemas = new List<Cinema>();
            Producers = new List<Producer>();
        }

        public List<Actor> Actors { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Producer> Producers { get; set; }
    }
}