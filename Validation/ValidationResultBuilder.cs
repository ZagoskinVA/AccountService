namespace AccountService.Validation
{
    public class ValidationResultBuilder
    {
        private ValidationResult validationResult;
        public ValidationResultBuilder()
        {
            validationResult = new ValidationResult();
        }

        public ValidationResultBuilder SetSuccessValidationStatus() 
        {
            validationResult.SetSuccessStatus();
            return this;
        }

        public ValidationResultBuilder SetFailedValidationStatus(string message) 
        {
            validationResult.SetErrorStatus(message);
            return this;
        }

        public ValidationResultBuilder SetFailedStatus(IEnumerable<string> messages) 
        {
            validationResult.SetErrorStatus(messages);
            return this;
        }

        public ValidationResult Build() => validationResult;
    }
}
