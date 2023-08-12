using WishCinema.Application.Requests.Base;

namespace WishCinema.Application.Requests.Test
{
    public class AddMovieRequest : BaseRequest
    {
        public string Title { get; set; } = null!;
        public string PosterLink { get; set;} = null!;
        public string Director { get; set; } = null!;
    }
}
