using AccountService.DataBase;
using AccountService.Interfaces;
using AccountService.Models;
using WebUtilities.Interfaces;
using WebUtilities.Model;

namespace AccountService.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext context;
        private readonly IOperationResultBuilder<OperationResult> operationResultBuilder;
        public AccountRepository(AccountContext context, IOperationResultBuilder<OperationResult> operationResultBuilder)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));
            if (operationResultBuilder == null)
                throw new ArgumentNullException(nameof(operationResultBuilder));
            this.context = context;
            this.operationResultBuilder = operationResultBuilder;
        }

        public async Task<IOperationResultBuilder<OperationResult>> RemoveAccount(Account account)
        {
            context.Accounts.Remove(account);
            await context.SaveChangesAsync();
            return operationResultBuilder.SetSuccessStatus();

        }

        public async Task<IOperationResultBuilder<OperationResult>> SaveAccount(Account account)
        {
            if (account.Id != 0)
            {
                var oldAccount = context.Accounts.FirstOrDefault(x => x.Id == account.Id);
                if(oldAccount == null)
                    return operationResultBuilder.SetFailureStatus().AddMessage($"Аккаунта с таким id: {account.Id} нет");
                oldAccount.Name = account.Name;
                oldAccount.Email = account.Email;
            }
            else 
            {
                context.Accounts.Add(account);
            }
            await context.SaveChangesAsync();
            return operationResultBuilder.SetSuccessStatus();
        }
    }
}
