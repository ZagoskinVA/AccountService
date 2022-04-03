using AccountService.Models;
using AccountService.Validation;

namespace AccountService.Interfaces
{

    public interface IValidationService<T> where T : Account
    {
        ValidationResult Validate(T model);
    }
}
