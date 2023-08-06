using WishCinema.Application.Result;
using WishCinema.Domain.Enums;

namespace WishCinema.Application.Results
{
    public class SuccessResult<T> : Result<T>
    {
        public SuccessResult(T data) 
        {
            Data = data;
        }
        public override string Error { get; }

        public override T Data { get; }

        public override ResultType ResultType => ResultType.Success;
    }
}
