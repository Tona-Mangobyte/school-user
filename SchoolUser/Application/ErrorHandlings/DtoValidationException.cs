using SchoolUser.Application.DTOs;

namespace SchoolUser.Application.ErrorHandlings
{
    public class DtoValidationException : Exception
    {
        public IEnumerable<ExceptionHandlingDto> Errors { get; }

        public DtoValidationException(IEnumerable<ExceptionHandlingDto> errors) : base()
        {
            Errors = errors;
        }
    }
}