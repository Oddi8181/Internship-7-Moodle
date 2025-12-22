using Application.Common.Validation;

namespace Application.Common.Model
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T? Value { get; private set; }
        public ValidationResult? ValidationResult { get; private set; }

        public bool HasErrors => !IsSuccess;
        private Result(bool isSucces, T? value, ValidationResult? validationResult)
        {
            IsSuccess = isSucces;
            Value = value;
            ValidationResult = validationResult;
        }
        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, null);
        }
        public static Result<T> Failure(ValidationResult validationResult)
        {
            return new Result<T>(false, default, validationResult);
        }
    }
}
