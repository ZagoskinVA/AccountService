using AccountService.Interfaces;
using AccountService.Models;
using Microsoft.AspNetCore.Mvc;
using WebUtilities.Model;
using WebUtilities.Services;

namespace AccountService.Controllers
{
    [Route("save/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            if(accountService == null)
                throw new ArgumentNullException(nameof(accountService));
            this.accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> SaveAccount(Account account) 
        {
            var operationResult = (await accountService.Save(account)).Build();
            if (operationResult.Status == OperationStatus.Success)
                return Ok(JsonService.GetOkJson(account));
            else
                return BadRequest(JsonService.GetErrorJson(account, operationResult.Messages));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAccount(Account account) 
        {
            var operationResult = (await accountService.Remove(account)).Build();
            if (operationResult.Status == OperationStatus.Success)
                return Ok();
            return BadRequest(JsonService.GetErrorJson(account, operationResult.Messages));
        }
    }
}
