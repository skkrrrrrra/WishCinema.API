using WishCinema.Application.Requests.Base;

namespace WishCinema.Application.Requests.Test
{
    public class AddProductRequest : BaseRequest
    {
        public string Title { get; set; } = null!;

        public string ImagePath { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; } = default!;
    }
}
