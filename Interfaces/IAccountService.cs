using AccountService.Models;
using WebUtilities.Interfaces;
using WebUtilities.Model;

namespace AccountService.Interfaces
{
    public interface IAccountService
    {
        Task<IOperationResultBuilder<OperationResult>> Save(Account account);
        Task<IOperationResultBuilder<OperationResult>> Remove(Account account);
    }
}
