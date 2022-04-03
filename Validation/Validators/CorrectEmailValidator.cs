using AccountService.Interfaces;
using AccountService.Models;
using System.Text.RegularExpressions;

namespace AccountService.Validation.Validators
{
    public class CorrectEmailValidator<T> : IValidationService<T> where T : Account
    {
        public ValidationResult Validate(T model)
        {
            if(model == null)
                throw new ArgumentNullException(nameof(model));
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(model.Email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success ? new ValidationResultBuilder().SetSuccessValidationStatus().Build() 
                : new ValidationResultBuilder().SetFailedValidationStatus($"Некорректный email: {model.Email}").Build();
        }
    }
}
