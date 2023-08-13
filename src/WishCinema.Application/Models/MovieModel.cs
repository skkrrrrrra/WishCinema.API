using WishCinema.Domain.Entities;

namespace WishCinema.Application.Models
{
    public class MovieModel
    {
        public string Title { get; set; } = null!;

        public string PosterLink { get; set; } = null!;

        public string Director { get; set; } = null!;

        public MovieModel(Movie movie)
        {
            Title = movie.Title;
            Director = movie.Director;
            PosterLink = movie.PosterLink;
        }
    }
}
