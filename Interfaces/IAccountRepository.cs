using AccountService.Models;
using WebUtilities.Interfaces;
using WebUtilities.Model;

namespace AccountService.Interfaces
{
    public interface IAccountRepository
    {
        Task<IOperationResultBuilder<OperationResult>> SaveAccount(Account account);
        Task<IOperationResultBuilder<OperationResult>> RemoveAccount(Account account);
    }
}
