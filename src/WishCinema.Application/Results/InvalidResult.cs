using WishCinema.Application.Result;
using WishCinema.Domain.Enums;

namespace WishCinema.Application.Results
{
    public class InvalidResult<T> : Result<T>
    {
        public InvalidResult(string error)
        {
            Error = error;
        }

        public override T Data => default(T);

        public override ResultType ResultType => ResultType.Invalid;

        public override string Error { get; }
    }
}
