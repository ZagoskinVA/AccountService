using AccountService.Interfaces;
using AccountService.Models;

namespace AccountService.Validation.Validators
{
    public class EmptyEmailValidator<T> : IValidationService<T> where T : Account
    {
        public ValidationResult Validate(T model)
        {
            return string.IsNullOrWhiteSpace(model.Email) ? new ValidationResultBuilder().SetFailedValidationStatus("Email не может быть пустым").Build() 
                : new ValidationResultBuilder().SetSuccessValidationStatus().Build();
        }
    }
}
