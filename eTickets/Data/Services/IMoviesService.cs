﻿using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropdownVM> GetNewMovieDropdownsValues();

        Task AddNewMovieAsync(NewMovieVM movie);

        Task UpdateMovieAsync(NewMovieVM movie);
    }
}