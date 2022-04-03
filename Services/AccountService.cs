using AccountService.Interfaces;
using AccountService.Models;
using WebUtilities.Interfaces;
using WebUtilities.Model;
using WebUtilities.Services;

namespace AccountService.Services
{
    public class AccountService : IAccountService
    {
        private readonly List<IValidationService<Account>> validationServices;
        private readonly IValidationSolver validationSolver;
        private readonly IAccountRepository accountRepository;

        public AccountService(List<IValidationService<Account>> validationServices, IValidationSolver validationSolver, IAccountRepository accountRepository)
        {
            if(validationServices == null)
                throw new ArgumentNullException(nameof(validationServices));
            if(validationSolver == null)
                throw new ArgumentNullException(nameof(validationSolver));
            if (accountRepository == null)
                throw new ArgumentNullException(nameof(accountRepository));
            this.validationServices = validationServices;
            this.validationSolver = validationSolver;
            this.accountRepository = accountRepository;
        }

        public async Task<IOperationResultBuilder<OperationResult>> Remove(Account account)
        {
            return await accountRepository.RemoveAccount(account);
        }

        public async Task<IOperationResultBuilder<OperationResult>> Save(Account account)
        {
            var isValid = validationSolver.IsValidModel(validationServices.Select(x => x.Validate(account)), out var messages);
            if (isValid) 
            {
                return await accountRepository.SaveAccount(account);
            }
            return new OperationResultBuilder<OperationResult>().SetFailureStatus().AddMessages(messages);

        }
    }
}
