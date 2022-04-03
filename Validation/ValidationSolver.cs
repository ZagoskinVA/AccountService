using AccountService.Interfaces;

namespace AccountService.Validation
{
    public class ValidationSolver : IValidationSolver
    {
        public bool IsValidModel(IEnumerable<ValidationResult> validationResults, out List<string> messages)
        {
            if(validationResults == null)
                throw new ArgumentNullException(nameof(validationResults));
            messages = new List<string>();
            var result = validationResults.All(x => x.Status == ValidationStatus.Success);
            if (result)
                return true;
            foreach (var failedResult in validationResults.Where(x => x.Status == ValidationStatus.Failed)) 
            {
                messages.AddRange(failedResult.Messages);
            }
            return false;
        }
    }
}
