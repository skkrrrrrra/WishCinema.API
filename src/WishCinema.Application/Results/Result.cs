using WishCinema.Domain.Enums;

namespace WishCinema.Application.Result
{
    public abstract class Result<T>
    {
        public abstract string Error { get; }
        public abstract T Data { get; }
        public abstract ResultType ResultType { get; }
    }
}
