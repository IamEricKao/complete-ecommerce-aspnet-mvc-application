using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM movieData)
        {
            var newMovie = new Movie()
            {
                Name = movieData.Name,
                Description = movieData.Description,
                Price = movieData.Price,
                ImageURL = movieData.ImageURL,
                StartDate = movieData.StartDate,
                EndDate = movieData.EndDate,
                MovieCategory = movieData.MovieCategory,
                CinemaId = movieData.CinemaId,
                ProducerId = movieData.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actor
            foreach (var actorId in movieData.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return movieDetails;
        }

        public async Task<NewMovieDropdownVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownVM()
            {
                Actors = await _context.Actors.OrderBy(a => a.FullName)
                .ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(c => c.Name)
                .ToListAsync(),
                Producers = await _context.Producers.OrderBy(c => c.FullName)
                .ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM movieData)
        {
            var dbMovie = await _context.Movies
                .Where(m => m.Id == movieData.Id)
                .FirstOrDefaultAsync();
            if (dbMovie != null)
            {
                dbMovie.Name = movieData.Name;
                dbMovie.Description = movieData.Description;
                dbMovie.Price = movieData.Price;
                dbMovie.ImageURL = movieData.ImageURL;
                dbMovie.StartDate = movieData.StartDate;
                dbMovie.EndDate = movieData.EndDate;
                dbMovie.MovieCategory = movieData.MovieCategory;
                dbMovie.CinemaId = movieData.CinemaId;
                dbMovie.ProducerId = movieData.ProducerId;

                await _context.SaveChangesAsync();
            };
            //Remove existing Actors
            var dbExistingActors = await _context.Actors_Movies
                .Where(m => m.MovieId == movieData.Id)
                .ToListAsync();
            _context.Actors_Movies.RemoveRange(dbExistingActors);

            foreach (var actorId in movieData.ActorIds)
            {
                var updateActor_Movie = new Actor_Movie()
                {
                    MovieId = movieData.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(updateActor_Movie);
            }
            await _context.SaveChangesAsync();
        }
    }
}