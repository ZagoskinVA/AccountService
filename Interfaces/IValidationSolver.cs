using AccountService.Validation;

namespace AccountService.Interfaces
{
    public interface IValidationSolver
    {
        bool IsValidModel(IEnumerable<ValidationResult> validationResults, out List<string> messages);
    }
}
