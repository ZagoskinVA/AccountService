using AccountService.Interfaces;
using AccountService.Models;

namespace AccountService.Validation.Validators
{
    public class EmptyNameValidator<T> : IValidationService<T> where T : Account
    {
        public ValidationResult Validate(T model)
        {
            return string.IsNullOrWhiteSpace(model.Name) ? new ValidationResultBuilder().SetFailedValidationStatus("Имя не может быть пустым").Build()
                : new ValidationResultBuilder().SetSuccessValidationStatus().Build();
        }
    }
}
