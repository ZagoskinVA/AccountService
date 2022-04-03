namespace AccountService.Validation
{
    public enum ValidationStatus
    {
        Success,
        Failed,
        Unknown
    }
    public class ValidationResult
    {
        private ValidationStatus status = ValidationStatus.Unknown;
        public ValidationStatus Status 
        {
            get { return status; }
            private set 
            {
                if (status != ValidationStatus.Unknown)
                    throw new Exception("Невозможно поменять статус проверки");
                status = value;
            }
        }
        public List<string> Messages { get; set; }
        public ValidationResult()
        {           
            Messages = new List<string>();
        }

        public void SetErrorStatus(string message) 
        {
            Status = ValidationStatus.Failed;
            Messages.Add(message);
        }

        public void SetErrorStatus(IEnumerable<string> messages) 
        {
            Status = ValidationStatus.Failed;
            Messages.AddRange(messages);
        }

        public void SetSuccessStatus() 
        {
            Status = ValidationStatus.Success;
        }
    }
}
